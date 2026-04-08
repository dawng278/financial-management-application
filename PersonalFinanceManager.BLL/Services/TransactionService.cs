using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Common.Models;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserService _userService;

        public event EventHandler TransactionChanged;
        public string LastError { get; private set; }

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository, ICategoryRepository categoryRepository, IUserService userService)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
            _userService = userService;
        }

        private int GetCurrentUserId()
        {
            var user = _userService?.GetCurrentUser();
            return user?.Id ?? 0;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _transactionRepository.GetByUserId(GetCurrentUserId());
        }

        public IEnumerable<Transaction> GetByAccount(int accountId)
        {
            return _transactionRepository.GetByAccountId(GetCurrentUserId(), accountId);
        }

        public IEnumerable<Transaction> GetRecent(int count)
        {
            return _transactionRepository.GetRecent(GetCurrentUserId(), count);
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime from, DateTime to)
        {
            return _transactionRepository.GetByDateRange(GetCurrentUserId(), from, to);
        }

        public bool Add(Transaction transaction)
        {
            LastError = null;
            var validator = new PersonalFinanceManager.BLL.Validators.TransactionValidator();
            var validationResult = validator.Validate(transaction);
            
            if (!validationResult.IsValid) return false;

            transaction.UserId = GetCurrentUserId();
            if (transaction.CreatedAt == default(DateTime)) transaction.CreatedAt = DateTime.Now;

            // Balance Check
            var account = _accountRepository.GetById(transaction.AccountId);
            if (account != null && transaction.Amount < 0 && (account.Balance + transaction.Amount) < 0)
            {
                LastError = "Insufficient funds in this account. Please select another account.";
                return false;
            }

            // Budget Check
            var category = _categoryRepository.GetById(transaction.CategoryId);
            if (category != null && category.BudgetLimit > 0 && transaction.Amount < 0)
            {
                decimal monthSpent = _transactionRepository.GetTotalByCategoryAndMonth(transaction.UserId, transaction.CategoryId, "Expense", transaction.TransactionDate.Year, transaction.TransactionDate.Month);
                if (Math.Abs(monthSpent) + Math.Abs(transaction.Amount) > category.BudgetLimit)
                {
                    LastError = string.Format(ConfigHelper.Translate("Budget limit exceeded for category '{0}'. Current month spending: {1}. Budget: {2}"), 
                                    category.Name, ConfigHelper.FormatGlobalCurrency(Math.Abs(monthSpent)), ConfigHelper.FormatGlobalCurrency(category.BudgetLimit));
                    return false;
                }
            }

            bool added = _transactionRepository.Insert(transaction) > 0;
            if (added)
            {
                if (account == null) account = _accountRepository.GetById(transaction.AccountId);
                if (account != null)
                {
                    account.Balance += transaction.Amount;
                    _accountRepository.UpdateBalance(account.Id, account.Balance);
                }
                TransactionChanged?.Invoke(this, EventArgs.Empty);
            }
            return added;
        }

        public bool Update(Transaction transaction)
        {
            LastError = null;
            var validator = new PersonalFinanceManager.BLL.Validators.TransactionValidator();
            var validationResult = validator.Validate(transaction);
            
            if (!validationResult.IsValid || transaction.Id <= 0) return false;

            transaction.UserId = GetCurrentUserId();
            var oldTx = _transactionRepository.GetById(transaction.Id);
            if (oldTx == null) return false;

            // Balance Check on Update
            if (oldTx.AccountId == transaction.AccountId)
            {
                var acc = _accountRepository.GetById(transaction.AccountId);
                if (acc != null && (acc.Balance - oldTx.Amount + transaction.Amount) < 0)
                {
                    LastError = "Insufficient funds in this account. Please select another account.";
                    return false;
                }
            }
            else
            {
                var newAcc = _accountRepository.GetById(transaction.AccountId);
                if (newAcc != null && (newAcc.Balance + transaction.Amount) < 0)
                {
                    LastError = "Insufficient funds in this account. Please select another account.";
                    return false;
                }
            }

            // Budget Check on Update
            if (transaction.Amount < 0)
            {
                var cat = _categoryRepository.GetById(transaction.CategoryId);
                if (cat != null && cat.BudgetLimit > 0)
                {
                    decimal monthSpent = _transactionRepository.GetTotalByCategoryAndMonth(transaction.UserId, transaction.CategoryId, "Expense", transaction.TransactionDate.Year, transaction.TransactionDate.Month);
                    decimal currentTxAbs = (oldTx.CategoryId == transaction.CategoryId) ? Math.Abs(oldTx.Amount) : 0;
                    if (Math.Abs(monthSpent) - currentTxAbs + Math.Abs(transaction.Amount) > cat.BudgetLimit)
                    {
                        LastError = string.Format(ConfigHelper.Translate("Budget limit exceeded for category '{0}'. Current month spending: {1}. Budget: {2}"), 
                                        cat.Name, ConfigHelper.FormatGlobalCurrency(Math.Abs(monthSpent) - currentTxAbs), ConfigHelper.FormatGlobalCurrency(cat.BudgetLimit));
                        return false;
                    }
                }
            }

            bool updated = _transactionRepository.Update(transaction);
            if (updated && oldTx != null)
            {
                if (oldTx.AccountId == transaction.AccountId)
                {
                    var account = _accountRepository.GetById(transaction.AccountId);
                    if (account != null)
                    {
                        account.Balance = account.Balance - oldTx.Amount + transaction.Amount;
                        _accountRepository.UpdateBalance(account.Id, account.Balance);
                    }
                }
                else
                {
                    var oldAcc = _accountRepository.GetById(oldTx.AccountId);
                    if (oldAcc != null) { oldAcc.Balance -= oldTx.Amount; _accountRepository.UpdateBalance(oldAcc.Id, oldAcc.Balance); }

                    var newAcc = _accountRepository.GetById(transaction.AccountId);
                    if (newAcc != null) { newAcc.Balance += transaction.Amount; _accountRepository.UpdateBalance(newAcc.Id, newAcc.Balance); }
                }
                TransactionChanged?.Invoke(this, EventArgs.Empty);
            }
            return updated;
        }

        public bool Delete(int id)
        {
            LastError = null;
            if (id <= 0) return false;
            var tx = _transactionRepository.GetById(id);
            bool deleted = _transactionRepository.Delete(id);
            if (deleted && tx != null)
            {
                var account = _accountRepository.GetById(tx.AccountId);
                if (account != null)
                {
                    account.Balance -= tx.Amount;
                    _accountRepository.UpdateBalance(account.Id, account.Balance);
                }
                TransactionChanged?.Invoke(this, EventArgs.Empty);
            }
            return deleted;
        }

        public decimal GetTotalIncome(DateTime from, DateTime to)
        {
            return _transactionRepository.GetTotalByType(GetCurrentUserId(), "Income", from, to);
        }

        public decimal GetTotalExpense(DateTime from, DateTime to)
        {
            return _transactionRepository.GetTotalByType(GetCurrentUserId(), "Expense", from, to);
        }

        public decimal GetMonthlySpentByCategory(int categoryId, int year, int month)
        {
            return _transactionRepository.GetTotalByCategoryAndMonth(GetCurrentUserId(), categoryId, "Expense", year, month);
        }
    }

    // B5: CSV Import Service
    public class CsvImportService
    {
        private readonly ITransactionRepository _transactionRepository;

        public CsvImportService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public CsvImportResult Import(string csvPath, int userId, int defaultAccountId, int defaultCategoryId)
        {
            var result = new CsvImportResult();

            if (string.IsNullOrWhiteSpace(csvPath) || !File.Exists(csvPath))
            {
                result.Errors.Add("File CSV không tồn tại.");
                return result;
            }

            var lines = File.ReadAllLines(csvPath);
            if (lines.Length <= 1)
            {
                result.Errors.Add("CSV không có dữ liệu.");
                return result;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                var lineNumber = i + 1;
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                try
                {
                    CsvTransactionDto dto;
                    if (!TryParseLine(lines[i], out dto))
                    {
                        result.Errors.Add("Dòng " + lineNumber + ": sai định dạng CSV.");
                        continue;
                    }

                    if (dto.Amount <= 0)
                    {
                        result.Errors.Add("Dòng " + lineNumber + ": Amount phải > 0.");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(dto.Type))
                    {
                        result.Errors.Add("Dòng " + lineNumber + ": Type là bắt buộc.");
                        continue;
                    }

                    var transaction = new Transaction
                    {
                        UserId = userId,
                        AccountId = defaultAccountId,
                        CategoryId = defaultCategoryId,
                        Amount = dto.Amount,
                        Type = dto.Type,
                        Note = dto.Note,
                        TransactionDate = dto.TransactionDate == default(DateTime) ? DateTime.Now : dto.TransactionDate,
                        CreatedAt = DateTime.Now,
                        ImportSource = "CSV"
                    };

                    if (_transactionRepository.Insert(transaction) > 0)
                    {
                        result.ImportedCount++;
                    }
                    else
                    {
                        result.Errors.Add("Dòng " + lineNumber + ": insert thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    result.Errors.Add("Dòng " + lineNumber + ": " + ex.Message);
                }
            }

            return result;
        }

        private static bool TryParseLine(string line, out CsvTransactionDto dto)
        {
            dto = null;

            var parts = ParseCsvLine(line);
            if (parts.Count < 5) return false;

            DateTime date;
            decimal amount;

            if (!DateTime.TryParse(parts[0], out date)) return false;
            if (!decimal.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out amount) &&
                !decimal.TryParse(parts[1], NumberStyles.Any, CultureInfo.CurrentCulture, out amount)) return false;

            dto = new CsvTransactionDto
            {
                TransactionDate = date,
                Amount = amount,
                Type = parts[2],
                Category = parts.Count > 3 ? parts[3] : null,
                Note = parts.Count > 4 ? parts[4] : null,
                Account = parts.Count > 5 ? parts[5] : null
            };

            return true;
        }

        private static List<string> ParseCsvLine(string line)
        {
            var result = new List<string>();
            var current = string.Empty;
            var inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }

                    continue;
                }

                if (c == ',' && !inQuotes)
                {
                    result.Add(current.Trim());
                    current = string.Empty;
                    continue;
                }

                current += c;
            }

            result.Add(current.Trim());
            return result;
        }
    }

    public class CsvImportResult
    {
        public int ImportedCount { get; set; }
        public List<string> Errors { get; private set; } = new List<string>();
    }
}

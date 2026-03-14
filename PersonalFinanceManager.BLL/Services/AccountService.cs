using System.Collections.Generic;
using PersonalFinanceManager.BLL.Interfaces;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserService _userService;

        public AccountService(IAccountRepository accountRepository, IUserService userService)
        {
            _accountRepository = accountRepository;
            _userService = userService;
        }

        private int GetCurrentUserId()
        {
            var user = _userService?.GetCurrentUser();
            return user?.Id ?? 0;
        }

        public IEnumerable<Account> GetByCurrentUser()
        {
            return _accountRepository.GetByUserId(GetCurrentUserId());
        }

        public Account GetById(int id)
        {
            return _accountRepository.GetById(id);
        }

        public bool Add(Account account)
        {
            if (account == null || string.IsNullOrWhiteSpace(account.AccountName)) return false;
            if (account.Balance < 0) return false;
            account.UserId = GetCurrentUserId();
            if (account.CreatedAt == default) account.CreatedAt = System.DateTime.Now;
            account.IsActive = true;
            return _accountRepository.Insert(account) > 0;
        }

        public bool Update(Account account)
        {
            if (account == null || account.Id <= 0 || string.IsNullOrWhiteSpace(account.AccountName)) return false;
            if (account.Balance < 0) return false;
            account.UserId = GetCurrentUserId();
            return _accountRepository.Update(account);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            var account = _accountRepository.GetById(id);
            if (account == null) return false;
            // Business rule: không xoá account còn số dư
            if (account.Balance > 0) return false;
            return _accountRepository.Delete(id);
        }

        public decimal GetTotalBalance()
        {
            return _accountRepository.GetTotalBalanceByUser(GetCurrentUserId());
        }
    }
}

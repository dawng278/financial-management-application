// File: PersonalFinanceManager.BLL/Validators/TransactionValidator.cs
using System;
using FluentValidation;
using PersonalFinanceManager.Models; // Giả sử Member A đã định nghĩa 

namespace PersonalFinanceManager.BLL.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.Amount)
                .Must((tx, amt) => amt != 0 || tx.ImportSource == "Milestone")
                .WithMessage("Số tiền phải khác 0.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Vui lòng chọn danh mục.");

            RuleFor(x => x.TransactionDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Ngày giao dịch không được ở tương lai.");
        }
    }
}
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
                .GreaterThan(0).WithMessage("Số tiền phải lớn hơn 0.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Vui lòng chọn danh mục.");

            RuleFor(x => x.TransactionDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Ngày giao dịch không được ở tương lai.");
        }
    }
}
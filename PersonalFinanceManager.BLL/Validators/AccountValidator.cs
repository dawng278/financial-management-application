using FluentValidation;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("Tên tài khoản không được để trống.");

            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Số dư không được âm.");

            RuleFor(x => x.AccountType)
                .Must(type => type == "Cash" || type == "BankAccount" || type == "EWallet")
                .WithMessage("Loại tài khoản phải là Cash, BankAccount hoặc EWallet.");
        }
    }
}

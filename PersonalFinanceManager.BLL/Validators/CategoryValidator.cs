using FluentValidation;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên danh mục không được để trống.")
                .MaximumLength(100).WithMessage("Tên danh mục không được vượt quá 100 ký tự.");

            RuleFor(x => x.Type)
                .Must(type => type == "Income" || type == "Expense")
                .WithMessage("Loại danh mục phải là Income hoặc Expense.");
        }
    }
}

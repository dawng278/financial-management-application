// File: PersonalFinanceManager.Tests/BLL/ValidatorTests.cs
using Xunit;
using PersonalFinanceManager.BLL.Validators; // Đảm bảo đúng namespace trong project BLL
using PersonalFinanceManager.Models;         // Thêm dòng này để nhận diện class Transaction

namespace PersonalFinanceManager.Tests.BLL
{
    public class TransactionValidatorTests
    {
        [Fact]
        public void Amount_Should_Be_Greater_Than_Zero()
        {
            // Khởi tạo Validator từ project BLL
            var validator = new TransactionValidator();

            // Khởi tạo Model từ project Models
            var result = validator.Validate(new Transaction { Amount = -100 });

            // Kiểm tra kết quả
            Assert.False(result.IsValid);
        }

        [Fact]
        public void AccountName_Should_Not_Be_Empty()
        {
            var validator = new AccountValidator();
            var result = validator.Validate(new Account { AccountName = "", Balance = 100, AccountType = "Cash" });
            Assert.False(result.IsValid);
        }

        [Fact]
        public void AccountType_Should_Be_Valid()
        {
            var validator = new AccountValidator();
            var result = validator.Validate(new Account { AccountName = "Test", Balance = 100, AccountType = "Invalid" });
            Assert.False(result.IsValid);
        }

        [Fact]
        public void CategoryType_Should_Be_Income_Or_Expense()
        {
            var validator = new CategoryValidator();
            var result = validator.Validate(new Category { Name = "Food", Type = "Invalid" });
            Assert.False(result.IsValid);
        }
    }
}
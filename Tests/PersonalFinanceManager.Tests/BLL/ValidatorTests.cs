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
    }
}
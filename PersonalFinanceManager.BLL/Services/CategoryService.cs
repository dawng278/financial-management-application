using System.Collections.Generic;
using PersonalFinanceManager.BLL.Interfaces;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserService _userService;

        public CategoryService(ICategoryRepository categoryRepository, IUserService userService)
        {
            _categoryRepository = categoryRepository;
            _userService = userService;
        }

        private int GetCurrentUserId()
        {
            var user = _userService?.GetCurrentUser();
            return user?.Id ?? 0;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetByUserId(GetCurrentUserId());
        }

        public IEnumerable<Category> GetByType(string type)
        {
            return _categoryRepository.GetByType(GetCurrentUserId(), type);
        }

        public IEnumerable<Category> GetDefaults()
        {
            return _categoryRepository.GetDefaults();
        }

        public bool Add(Category category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name)) return false;
            if (category.Type != "Income" && category.Type != "Expense") return false;
            category.UserId = GetCurrentUserId();
            return _categoryRepository.Insert(category) > 0;
        }

        public bool Update(Category category)
        {
            if (category == null || category.Id <= 0 || string.IsNullOrWhiteSpace(category.Name)) return false;
            if (category.Type != "Income" && category.Type != "Expense") return false;
            category.UserId = GetCurrentUserId();
            return _categoryRepository.Update(category);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            // Không cho phép xoá category hệ thống (IsDefault)
            var category = _categoryRepository.GetById(id);
            if (category == null || category.IsDefault) return false;
            return _categoryRepository.Delete(id);
        }
    }
}

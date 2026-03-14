using System;
using System.Collections.Generic;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.BLL.Interfaces;

namespace PersonalFinanceManager.Infrastructure.DI
{
    public static class DependencyContainer
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
        private static bool _initialized;

        public static void Initialize()
        {
            _services.Clear();
            RegisterServices();
            _initialized = true;
        }

        private static void RegisterServices()
        {
            // ============================================================
            // PHASE 2: REAL (Mở comment khi B xong DAL - Sprint 2 Task A6)
            // ============================================================
            
            var dbHelper = new PersonalFinanceManager.Common.Helpers.DbHelper();
            var userService = new PersonalFinanceManager.Common.Mock.MockUserService(); // SQLite-backed implementation
            
            var accountRepo = new PersonalFinanceManager.DAL.Repositories.AccountRepository(dbHelper);
            var categoryRepo = new PersonalFinanceManager.DAL.Repositories.CategoryRepository(dbHelper);
            var transactionRepo = new PersonalFinanceManager.DAL.Repositories.TransactionRepository(dbHelper);
            
            var accountService = new PersonalFinanceManager.BLL.Services.AccountService(accountRepo, userService);
            var categoryService = new PersonalFinanceManager.BLL.Services.CategoryService(categoryRepo);
            var transactionService = new PersonalFinanceManager.BLL.Services.TransactionService(transactionRepo, userService);
            
            _services[typeof(IUserService)] = userService;
            _services[typeof(IAccountService)] = accountService;
            _services[typeof(ICategoryService)] = categoryService;
            _services[typeof(PersonalFinanceManager.BLL.Interfaces.ITransactionService)] = transactionService;
        }

        /// <summary>
        /// Dùng ở khắp nơi để lấy service: 
        /// var svc = DependencyContainer.Resolve&lt;ITransactionService&gt;();
        /// </summary>
        public static T Resolve<T>()
        {
            if (!_initialized)
                throw new InvalidOperationException("Container chưa được khởi tạo. Gọi Initialize() trước.");

            object instance;
            if (_services.TryGetValue(typeof(T), out instance))
                return (T)instance;

            throw new InvalidOperationException($"Chưa đăng ký service cho kiểu {typeof(T).FullName}");
        }
    }
}
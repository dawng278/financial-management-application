using System;
using System.Collections.Generic;
using PersonalFinanceManager.Common.Interfaces;

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
            // PHASE 1: MOCK (C dùng trong Sprint 1 - B chưa xong DAL)
            // Khi B xong, A chỉ cần comment block này, bỏ comment block bên dưới
            // ============================================================
            _services[typeof(IUserService)] = new PersonalFinanceManager.Common.Mock.MockUserService();
            _services[typeof(ITransactionService)] = new PersonalFinanceManager.Common.Mock.MockTransactionService();

            // ============================================================
            // PHASE 2: REAL (Mở comment khi B xong DAL - Sprint 2 Task A6)
            // ============================================================
            // _container.RegisterType<IUserRepository,
            //     PersonalFinanceManager.DAL.Repositories.UserRepository>(new ContainerControlledLifetimeManager());
            //
            // _container.RegisterType<ITransactionRepository,
            //     PersonalFinanceManager.DAL.Repositories.TransactionRepository>(new ContainerControlledLifetimeManager());
            //
            // _container.RegisterType<IUserService,
            //     PersonalFinanceManager.BLL.Services.UserService>(new ContainerControlledLifetimeManager());
            //
            // _container.RegisterType<ITransactionService,
            //     PersonalFinanceManager.BLL.Services.TransactionService>(new ContainerControlledLifetimeManager());
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
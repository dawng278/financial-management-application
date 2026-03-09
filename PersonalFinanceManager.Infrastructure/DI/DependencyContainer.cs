using System;
using Unity;
using Unity.Lifetime;
using PersonalFinanceManager.Common.Interfaces;

namespace PersonalFinanceManager.Infrastructure.DI
{
    public static class DependencyContainer
    {
        private static IUnityContainer _container;

        public static IUnityContainer Current => _container
            ?? throw new InvalidOperationException("Container chưa được khởi tạo. Gọi Initialize() trước.");

        public static void Initialize()
        {
            _container = new UnityContainer();
            RegisterServices();
        }

        private static void RegisterServices()
        {
            // ============================================================
            // PHASE 1: MOCK (C dùng trong Sprint 1 - B chưa xong DAL)
            // Khi B xong, A chỉ cần comment block này, bỏ comment block bên dưới
            // ============================================================
            _container.RegisterType<IUserService,
                PersonalFinanceManager.Common.Mock.MockUserService>(new ContainerControlledLifetimeManager());

            _container.RegisterType<ITransactionService,
                PersonalFinanceManager.Common.Mock.MockTransactionService>(new ContainerControlledLifetimeManager());

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
            return _container.Resolve<T>();
        }
    }
}
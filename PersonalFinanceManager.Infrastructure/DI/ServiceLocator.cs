using PersonalFinanceManager.Common.Interfaces;

namespace PersonalFinanceManager.Infrastructure.DI
{
    /// <summary>
    /// Shortcut để lấy services. Dùng trong UI Forms:
    ///   var svc = ServiceLocator.TransactionService;
    /// </summary>
    public static class ServiceLocator
    {
        public static IUserService UserService
            => DependencyContainer.Resolve<IUserService>();

        public static ITransactionService TransactionService
            => DependencyContainer.Resolve<ITransactionService>();

        // Khi có thêm service, A thêm vào đây
        // public static IAccountService AccountService
        //     => DependencyContainer.Resolve<IAccountService>();
    }
}
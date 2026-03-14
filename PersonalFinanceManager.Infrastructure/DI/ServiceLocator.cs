using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.BLL.Interfaces;
using System;
using System.IO;

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

        public static PersonalFinanceManager.BLL.Interfaces.ITransactionService TransactionService
            => DependencyContainer.Resolve<PersonalFinanceManager.BLL.Interfaces.ITransactionService>();

        public static IAccountService AccountService
            => DependencyContainer.Resolve<IAccountService>();

        public static ICategoryService CategoryService
            => DependencyContainer.Resolve<ICategoryService>();
    }
}

namespace PersonalFinanceManager.Infrastructure.Services
{
    public class BackupService
    {
        private readonly string _dbPath;

        public BackupService()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PersonalFinance.db");
        }

        public string CreateBackup(string destinationFolder)
        {
            if (!File.Exists(_dbPath))
                throw new FileNotFoundException("Không tìm thấy file database.", _dbPath);

            if (string.IsNullOrWhiteSpace(destinationFolder))
                throw new ArgumentException("Đường dẫn thư mục backup không hợp lệ.", nameof(destinationFolder));

            Directory.CreateDirectory(destinationFolder);

            var backupFile = Path.Combine(destinationFolder,
                "PersonalFinance_backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".db");

            File.Copy(_dbPath, backupFile, true);
            return backupFile;
        }

        public void RestoreBackup(string backupFilePath)
        {
            if (string.IsNullOrWhiteSpace(backupFilePath) || !File.Exists(backupFilePath))
                throw new FileNotFoundException("Không tìm thấy file backup.", backupFilePath);

            File.Copy(backupFilePath, _dbPath, true);
        }
    }
}

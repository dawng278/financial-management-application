using PersonalFinanceManager.Common.Interfaces;

namespace PersonalFinanceManager.BLL.Interfaces
{
    // Re-export để các layer (UI, Tests) chỉ cần reference BLL.Interfaces
    public interface ITransactionService : Common.Interfaces.ITransactionService
    {
    }
}

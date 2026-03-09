using System.Collections.Generic;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Insert(T entity);      // Trả về Id vừa insert
        bool Update(T entity);
        bool Delete(int id);
    }
}
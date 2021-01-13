using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Function.App.Data.DatabaseManager.Interfaces
{
    public interface IRepository<T>
    {
        Task<int> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Find(string sql, object param = null);
        Task<bool> DeleteAsync(T entity);
    }
}

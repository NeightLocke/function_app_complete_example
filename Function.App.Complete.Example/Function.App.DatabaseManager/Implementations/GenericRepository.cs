using Function.App.DatabaseManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Function.App.DatabaseManager.Implementations
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IClientContextStrategy<T> _clientContext;

        public GenericRepository(IClientContextStrategy<T> clientContext)
        {
            _clientContext = clientContext;
        }

        public async virtual Task<int> AddAsync(T entity)
        {
            try
            {
                return await _clientContext.AddAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return -1;
            }
        }

        public async virtual Task<bool> DeleteAsync(T entity)
        {
            try
            {
                return await _clientContext.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return false;
            }
        }

        public async virtual Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _clientContext.Find(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return null;
            }
        }

        public async virtual Task<IEnumerable<T>> Find(string sql, object param = null)
        {
            try
            {
                return await _clientContext.Find(sql, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return null;
            }
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _clientContext.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return null;
            }
        }

        public async virtual Task<T> GetAsync(string id)
        {
            try
            {
                return await _clientContext.GetAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return null;
            }
        }

        public async virtual Task<T> UpdateAsync(T entity)
        {
            try
            {
                return await _clientContext.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                return null;
            }
        }
    }
}
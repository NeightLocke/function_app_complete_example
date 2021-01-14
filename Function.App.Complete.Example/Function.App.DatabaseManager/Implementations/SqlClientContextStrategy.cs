using Function.App.DatabaseManager.Interfaces;
using Function.App.DatabaseManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Function.App.DatabaseManager.Implementations
{
    public abstract class SqlClientContextStrategy<T> : IDisposable, IClientContextStrategy<T> where T : class
    {
        protected IDbConnection Connection { get; set; }

        public SqlClientContextStrategy(SqlClientConfig sqlConfig)
        {
            try
            {
                Connection = new SqlConnection(sqlConfig.ConnectionString + ";" + sqlConfig.UserId + ";" + sqlConfig.Password);
                Connection.Open();
            }
            catch (Exception ex)
            {
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public abstract Task<int> AddAsync(T entity);

        public abstract Task<bool> DeleteAsync(T entity);

        public abstract Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        public abstract Task<IEnumerable<T>> Find(string sql, object param = null);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T> GetAsync(string id);

        public abstract Task<T> UpdateAsync(T entity);
    }
}
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular_InterfaceContracts.Generic
{
    public interface IGenericRepo<T> : IDisposable where T : class
    {
        Task<IQueryable<T>> GetAll();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        List<T> Find(Func<T, bool> predicate);
        Task<T> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Delete(T entity);
        Task Delete(int id);
        Task DeleteRange(IEnumerable<T> entities);
        Task<T> Edit(T entity);
        Task EditRange(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(decimal id);
        T GetById(int id);
        void SQLQuery(string sql, params object[] parameters);
        T ReloadEntity(T entity);
        //DataSet GetDataSet(string commandText, params SqlParameter[] parameters);

    }
}

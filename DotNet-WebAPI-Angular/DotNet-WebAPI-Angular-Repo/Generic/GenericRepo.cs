using DotNet_WebAPI_Angular_InterfaceContracts.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular_Repo.Generic
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<IQueryable<T>> GetAll()
        {
            IQueryable<T> query = null;
            await Task.Run(() =>
            {
                query = _unitOfWork.Context.Set<T>();
            });
            return query;
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<T>().Where(predicate).ToListAsync();
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).ToList();
        }

        public async Task<T> Add(T entity)
        {
            var savedEntity = _unitOfWork.Context.Set<T>().Add(entity);
            await _unitOfWork.CommitAsync();
            return savedEntity.Entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            _unitOfWork.Context.Set<T>().AddRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async virtual Task<T> Edit(T entity)
        {
            var savedEntity = _unitOfWork.Context.Set<T>().Update(entity);
            await _unitOfWork.CommitAsync();
            return savedEntity.Entity;
        }

        public async virtual Task EditRange(IEnumerable<T> entities)
        {
            _unitOfWork.Context.Set<T>().UpdateRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async virtual Task Delete(T entity)
        {
            _unitOfWork.Context.Set<T>().Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async virtual Task DeleteRange(IEnumerable<T> entities)
        {
            _unitOfWork.Context.Set<T>().RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var existingRecord = _unitOfWork.Context.Set<T>().Find(id);
            if (existingRecord != null)
                _unitOfWork.Context.Set<T>().Remove(existingRecord);
            await _unitOfWork.CommitAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(decimal id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _unitOfWork.Context.Set<T>().Find(id);
        }

        public void SQLQuery(string sql, params object[] parameters)
        {
            _unitOfWork.Context.Database.ExecuteSqlCommand(sql, parameters);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

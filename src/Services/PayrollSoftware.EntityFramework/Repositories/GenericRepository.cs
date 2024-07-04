using Microsoft.EntityFrameworkCore;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.EntityFramework.Contracts;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Task = System.Threading.Tasks.Task;

namespace PayrollSoftware.EntityFramework.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TaskManagementContext _context;
        protected readonly ObservableCollection<T> _datas;

        public GenericRepository(TaskManagementContext context)
        {
            _context = context;
            _datas = new();
        }

        public Task Add(T entity)
        {
            return Task.Factory.StartNew(() => _context.Set<T>().Add(entity));
        }

        public Task AddRange(IEnumerable<T> entities)
        {
            return Task.Factory.StartNew(() => _context.Set<T>().AddRange(entities));
        }

        public Task<T> First(Expression<Func<T, bool>> expression)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    return _context.Set<T>().First(expression);
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }

        public Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return Task.Factory.StartNew(() => _context.Set<T>().FirstOrDefault(expression));
        }

        public virtual Task<T?> GetByCode(string code)
        {
            return default;
        }

        public virtual Task<T?> GetById(int id)
        {
            return default;
        }

        public Task<bool> Remove(T entity)
        {
            return Task.Factory.StartNew(() =>
            {
                if (entity == null)
                {
                    return false;
                }
                _context.Set<T>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                return true;
            });
        }

        public virtual Task<bool> Update(T entity)
        {
            return Task.Factory.StartNew(() =>
            {
                if (entity == null)
                {
                    return false;
                }
                _context.Set<T>().Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            });
        }

        public Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            return Task.Factory.StartNew(() =>
            {
                return _context.Set<T>().Where(expression).ToList();
            });
        }
    }
}
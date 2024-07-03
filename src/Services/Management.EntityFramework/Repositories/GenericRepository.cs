using Management.Core.Models.SchoolManager;
using Management.EntityFramework.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Management.EntityFramework.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SchoolManagerContext _context;

        public GenericRepository(SchoolManagerContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public T First(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _context.Set<T>().First(expression);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T? FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public ObservableCollection<T> GetAll()
        {
            
            return new(_context.Set<T>().AsTracking().ToList());
        }

        public abstract T? GetById(int id);

        public abstract T? GetByCode(string code);

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public List<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }
    }
}
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace PayrollSoftware.EntityFramework.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        Task<T> First(Expression<Func<T, bool>> expression);

        Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);

        Task<T?> GetByCode(string code);

        Task<T?> GetById(int id);
        Task<bool> Remove(T entity);

        Task<bool> Update(T entity);

        Task<List<T>> Where(Expression<Func<T, bool>> expression);
    }
}
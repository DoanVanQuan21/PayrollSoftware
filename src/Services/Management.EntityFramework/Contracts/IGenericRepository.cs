using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Management.EntityFramework.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(int id);

        T? GetByCode(string code);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        ObservableCollection<T> GetAll();

        List<T> Where(Expression<Func<T, bool>> expression);

        T First(Expression<Func<T, bool>> expression);

        T? FirstOrDefault(Expression<Func<T, bool>> expression);
    }
}
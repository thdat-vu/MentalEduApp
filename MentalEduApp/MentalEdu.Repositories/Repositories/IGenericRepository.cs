using System.Linq.Expressions;

namespace MentalEdu.Repositories.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(object id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task<bool> DeleteAsync(object id);
        void Delete(T entity);
    }
}
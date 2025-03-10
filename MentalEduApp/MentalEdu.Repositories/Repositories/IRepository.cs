using System.Linq.Expressions;

namespace MentalEdu.Repositories.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Get methods
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        // Add methods
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);

        // Update methods
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        // Remove methods
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        // Count methods
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        // Exists method
        bool Exists(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
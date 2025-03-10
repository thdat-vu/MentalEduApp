using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        // Add specific methods for Blog entity
        Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count);
        Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(string category);
    }
}
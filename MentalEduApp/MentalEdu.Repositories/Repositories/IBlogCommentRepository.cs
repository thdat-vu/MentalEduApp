using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IBlogCommentRepository : IRepository<BlogComment>
    {
        // Add specific methods for BlogComment entity
        Task<IEnumerable<BlogComment>> GetCommentsByBlogIdAsync(Guid blogId);
        Task<IEnumerable<BlogComment>> GetCommentsByUserIdAsync(Guid userId);
    }
}
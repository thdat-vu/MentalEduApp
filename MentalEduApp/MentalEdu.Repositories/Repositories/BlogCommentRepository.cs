using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class BlogCommentRepository : Repository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BlogComment>> GetCommentsByBlogIdAsync(Guid blogId)
        {
            return await _dbSet.Where(bc => bc.BlogId == blogId && bc.ActiveFlag == true)
                              .OrderByDescending(bc => bc.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<BlogComment>> GetCommentsByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(bc => bc.UserId == userId && bc.ActiveFlag == true)
                              .OrderByDescending(bc => bc.CreatedAt)
                              .ToListAsync();
        }
    }
}
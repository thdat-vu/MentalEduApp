using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count)
        {
            return await _dbSet.Where(b => b.ActiveFlag == true)
                              .OrderByDescending(b => b.CreatedAt)
                              .Take(count)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(string category)
        {
            return await _dbSet.Where(b => b.Category == category && b.ActiveFlag == true)
                              .OrderByDescending(b => b.CreatedAt)
                              .ToListAsync();
        }
    }
}
using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly MentalEduContext _dbContext;

        public BlogRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Blog>> GetActiveBlogsAsync()
        {
            return await _dbContext.Blogs
                .Where(b => b.ActiveFlag == true)
                .Include(b => b.Author)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        public async Task<Blog?> GetBlogWithCommentsAsync(Guid id)
        {
            return await _dbContext.Blogs
                .Include(b => b.Author)
                .Include(b => b.BlogComments.Where(bc => bc.ActiveFlag == true))
                    .ThenInclude(bc => bc.User)
                .FirstOrDefaultAsync(b => b.Id == id && b.ActiveFlag == true);
        }

        public async Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(string category)
        {
            return await _dbContext.Blogs
                .Where(b => b.Category == category && b.ActiveFlag == true)
                .Include(b => b.Author)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }
    }
}
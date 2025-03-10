using MentalEdu.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetActiveBlogsAsync();
        Task<Blog?> GetBlogWithCommentsAsync(Guid id);
        Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(string category);
    }
}
using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class ProgramCategoryRepository : Repository<ProgramCategory>, IProgramCategoryRepository
    {
        public ProgramCategoryRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProgramCategory>> GetActiveCategoriesAsync()
        {
            return await _dbSet.Where(pc => pc.ActiveFlag == true)
                              .OrderBy(pc => pc.Name)
                              .ToListAsync();
        }
    }
}
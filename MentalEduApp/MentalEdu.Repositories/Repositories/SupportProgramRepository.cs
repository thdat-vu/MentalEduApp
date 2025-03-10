using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class SupportProgramRepository : Repository<SupportProgram>, ISupportProgramRepository
    {
        public SupportProgramRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SupportProgram>> GetProgramsByCategoryIdAsync(Guid categoryId)
        {
            return await _dbSet.Where(sp => sp.CategoryId == categoryId && sp.ActiveFlag == true)
                              .OrderBy(sp => sp.ProgramName)
                              .ToListAsync();
        }

        public async Task<IEnumerable<SupportProgram>> GetActiveProgramsAsync()
        {
            var now = DateTime.Now;
            return await _dbSet.Where(sp => sp.ActiveFlag == true && 
                                          (sp.EndDate == null || sp.EndDate > now))
                              .OrderBy(sp => sp.ProgramName)
                              .ToListAsync();
        }
    }
}
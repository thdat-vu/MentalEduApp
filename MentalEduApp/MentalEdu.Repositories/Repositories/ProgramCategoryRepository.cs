using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class ProgramCategoryRepository : GenericRepository<ProgramCategory>, IProgramCategoryRepository
    {
        private readonly MentalEduContext _dbContext;

        public ProgramCategoryRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<ProgramCategory>> GetActiveCategoriesAsync()
        {
            return await _dbContext.ProgramCategories
                .Where(c => c.ActiveFlag == true)
                .ToListAsync();
        }

        public async Task<ProgramCategory?> GetCategoryWithProgramsAsync(Guid id)
        {
            return await _dbContext.ProgramCategories
                .Include(c => c.SupportPrograms.Where(p => p.ActiveFlag == true))
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
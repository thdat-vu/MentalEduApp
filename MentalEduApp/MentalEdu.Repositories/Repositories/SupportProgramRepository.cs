using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class SupportProgramRepository : GenericRepository<SupportProgram>, ISupportProgramRepository
    {
        private readonly MentalEduContext _dbContext;

        public SupportProgramRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<SupportProgram>> GetActiveProgramsAsync()
        {
            return await _dbContext.SupportPrograms
                .Where(p => p.ActiveFlag == true)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<SupportProgram>> GetProgramsByCategoryAsync(Guid categoryId)
        {
            return await _dbContext.SupportPrograms
                .Where(p => p.CategoryId == categoryId && p.ActiveFlag == true)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<SupportProgram?> GetProgramWithDetailsAsync(Guid id)
        {
            return await _dbContext.SupportPrograms
                .Include(p => p.Category)
                .Include(p => p.UserPrograms)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
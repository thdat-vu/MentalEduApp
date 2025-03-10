using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class PsychologistRepository : GenericRepository<Psychologist>, IPsychologistRepository
    {
        private readonly MentalEduContext _dbContext;

        public PsychologistRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Psychologist>> GetActivePsychologistsAsync()
        {
            return await _dbContext.Psychologists
                .Where(p => p.ActiveFlag == true)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Psychologist?> GetPsychologistWithSpecializationsAsync(Guid id)
        {
            return await _dbContext.Psychologists
                .Include(p => p.PsychologistSpecializations)
                    .ThenInclude(ps => ps.Specialization)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id && p.ActiveFlag == true);
        }

        public async Task<IEnumerable<Psychologist>> GetPsychologistsBySpecializationAsync(Guid specializationId)
        {
            return await _dbContext.Psychologists
                .Where(p => p.ActiveFlag == true)
                .Include(p => p.PsychologistSpecializations)
                .Include(p => p.User)
                .Where(p => p.PsychologistSpecializations.Any(ps => ps.SpecializationId == specializationId))
                .ToListAsync();
        }
    }
}
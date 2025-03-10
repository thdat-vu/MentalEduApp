using MentalEdu.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface ISupportProgramRepository : IGenericRepository<SupportProgram>
    {
        Task<IEnumerable<SupportProgram>> GetActiveProgramsAsync();
        Task<IEnumerable<SupportProgram>> GetProgramsByCategoryAsync(Guid categoryId);
        Task<SupportProgram?> GetProgramWithDetailsAsync(Guid id);
    }
}
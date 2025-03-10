using MentalEdu.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface IProgramCategoryRepository : IGenericRepository<ProgramCategory>
    {
        Task<IEnumerable<ProgramCategory>> GetActiveCategoriesAsync();
        Task<ProgramCategory?> GetCategoryWithProgramsAsync(Guid id);
    }
}
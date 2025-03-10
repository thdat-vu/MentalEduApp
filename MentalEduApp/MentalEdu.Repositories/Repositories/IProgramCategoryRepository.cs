using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IProgramCategoryRepository : IRepository<ProgramCategory>
    {
        // Add specific methods for ProgramCategory entity
        Task<IEnumerable<ProgramCategory>> GetActiveCategoriesAsync();
    }
}
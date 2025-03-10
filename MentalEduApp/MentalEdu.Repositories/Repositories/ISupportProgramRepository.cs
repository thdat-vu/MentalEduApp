using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface ISupportProgramRepository : IRepository<SupportProgram>
    {
        // Add specific methods for SupportProgram entity
        Task<IEnumerable<SupportProgram>> GetProgramsByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<SupportProgram>> GetActiveProgramsAsync();
    }
}
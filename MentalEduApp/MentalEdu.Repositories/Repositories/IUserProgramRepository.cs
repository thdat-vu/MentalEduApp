using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IUserProgramRepository : IRepository<UserProgram>
    {
        // Add specific methods for UserProgram entity
        Task<IEnumerable<UserProgram>> GetProgramsByUserIdAsync(Guid userId);
        Task<IEnumerable<UserProgram>> GetUsersByProgramIdAsync(Guid programId);
        Task<IEnumerable<UserProgram>> GetProgramsByStatusAsync(string status);
    }
}
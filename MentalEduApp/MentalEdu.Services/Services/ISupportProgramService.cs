using MentalEdu.Repositories.Models;

namespace MentalEdu.Services.Services
{
    public interface ISupportProgramService
    {
        Task<IEnumerable<SupportProgram>> GetAllProgramsAsync();
        Task<IEnumerable<SupportProgram>> GetActiveProgramsAsync();
        Task<SupportProgram> GetProgramByIdAsync(Guid id);
        Task<IEnumerable<SupportProgram>> GetProgramsByCategoryIdAsync(Guid categoryId);
        Task<SupportProgram> CreateProgramAsync(SupportProgram program);
        Task UpdateProgramAsync(SupportProgram program);
        Task DeleteProgramAsync(Guid id);
    }
}
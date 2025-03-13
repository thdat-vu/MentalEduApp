using MentalEdu.Repositories.Models;

namespace MentalEdu.Services.Services
{
    public interface IProgramCategoryService
    {
        Task<IEnumerable<ProgramCategory>> GetAllCategoriesAsync();
        Task<IEnumerable<ProgramCategory>> GetActiveCategoriesAsync();
        Task<ProgramCategory> GetCategoryByIdAsync(Guid id);
        Task<ProgramCategory> CreateCategoryAsync(ProgramCategory category);
        Task UpdateCategoryAsync(ProgramCategory category);
        Task DeleteCategoryAsync(Guid id);
    }
}
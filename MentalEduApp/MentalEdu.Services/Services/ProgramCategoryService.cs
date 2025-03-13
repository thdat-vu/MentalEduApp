using MentalEdu.Repositories.Models;
using MentalEdu.Repositories.UnitOfWork;

namespace MentalEdu.Services.Services
{
    public class ProgramCategoryService : IProgramCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProgramCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProgramCategory>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.ProgramCategories.GetAllAsync();
        }

        public async Task<IEnumerable<ProgramCategory>> GetActiveCategoriesAsync()
        {
            return await _unitOfWork.ProgramCategories.GetActiveCategoriesAsync();
        }

        public async Task<ProgramCategory> GetCategoryByIdAsync(Guid id)
        {
            return await _unitOfWork.ProgramCategories.GetByIdAsync(id);
        }

        public async Task<ProgramCategory> CreateCategoryAsync(ProgramCategory category)
        {
            category.Id = Guid.NewGuid();
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            category.ActiveFlag = true;

            await _unitOfWork.ProgramCategories.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return category;
        }

        public async Task UpdateCategoryAsync(ProgramCategory category)
        {
            var existingCategory = await _unitOfWork.ProgramCategories.GetByIdAsync(category.Id);
            if (existingCategory == null)
                throw new KeyNotFoundException($"Category with ID {category.Id} not found");

            existingCategory.Name = category.Name;
            existingCategory.ImageUrl = category.ImageUrl;
            existingCategory.UpdatedAt = DateTime.Now;

            _unitOfWork.ProgramCategories.Update(existingCategory);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _unitOfWork.ProgramCategories.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found");

            // Soft delete
            category.ActiveFlag = false;
            category.UpdatedAt = DateTime.Now;

            _unitOfWork.ProgramCategories.Update(category);
            await _unitOfWork.CompleteAsync();
        }
    }
}
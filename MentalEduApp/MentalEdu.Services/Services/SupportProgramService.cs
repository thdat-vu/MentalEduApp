using MentalEdu.Repositories.Models;
using MentalEdu.Repositories.UnitOfWork;

namespace MentalEdu.Services.Services
{
    public class SupportProgramService : ISupportProgramService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupportProgramService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SupportProgram>> GetAllProgramsAsync()
        {
            return await _unitOfWork.SupportPrograms.GetAllAsync();
        }

        public async Task<IEnumerable<SupportProgram>> GetActiveProgramsAsync()
        {
            return await _unitOfWork.SupportPrograms.FindAsync(p => p.ActiveFlag == true);
        }

        public async Task<SupportProgram> GetProgramByIdAsync(Guid id)
        {
            return await _unitOfWork.SupportPrograms.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SupportProgram>> GetProgramsByCategoryIdAsync(Guid categoryId)
        {
            return await _unitOfWork.SupportPrograms.FindAsync(p => p.CategoryId == categoryId && p.ActiveFlag == true);
        }

        public async Task<SupportProgram> CreateProgramAsync(SupportProgram program)
        {
            program.Id = Guid.NewGuid();
            program.CreatedAt = DateTime.Now;
            program.UpdatedAt = DateTime.Now;
            program.ActiveFlag = true;

            await _unitOfWork.SupportPrograms.AddAsync(program);
            await _unitOfWork.CompleteAsync();

            return program;
        }

        public async Task UpdateProgramAsync(SupportProgram program)
        {
            var existingProgram = await _unitOfWork.SupportPrograms.GetByIdAsync(program.Id);
            if (existingProgram == null)
                throw new KeyNotFoundException($"Program with ID {program.Id} not found");

            existingProgram.ProgramName = program.ProgramName;
            existingProgram.Description = program.Description;
            existingProgram.CategoryId = program.CategoryId;
            existingProgram.ImageUrl = program.ImageUrl;
            existingProgram.StartDate = program.StartDate;
            existingProgram.EndDate = program.EndDate;
            existingProgram.UpdatedAt = DateTime.Now;

            _unitOfWork.SupportPrograms.Update(existingProgram);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProgramAsync(Guid id)
        {
            var program = await _unitOfWork.SupportPrograms.GetByIdAsync(id);
            if (program == null)
                throw new KeyNotFoundException($"Program with ID {id} not found");

            // Soft delete
            program.ActiveFlag = false;
            program.UpdatedAt = DateTime.Now;

            _unitOfWork.SupportPrograms.Update(program);
            await _unitOfWork.CompleteAsync();
        }
    }
}
using MentalEdu.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        
        // Specific repositories
        IProgramCategoryRepository ProgramCategories { get; }
        ISupportProgramRepository SupportPrograms { get; }
        IUserProgramRepository UserPrograms { get; }
        IUserAccountRepository UserAccounts { get; }
        IPsychologistRepository Psychologists { get; }
        IAppointmentRepository Appointments { get; }
        IBlogRepository Blogs { get; }
        
        Task<int> CompleteAsync();
    }
}
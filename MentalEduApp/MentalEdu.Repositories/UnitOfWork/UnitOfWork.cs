using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MentalEduContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        // Specific repositories
        private IProgramCategoryRepository _programCategoryRepository;
        private ISupportProgramRepository _supportProgramRepository;
        private IUserProgramRepository _userProgramRepository;
        private IUserAccountRepository _userAccountRepository;
        private IPsychologistRepository _psychologistRepository;
        private IAppointmentRepository _appointmentRepository;
        private IBlogRepository _blogRepository;

        public UnitOfWork(MentalEduContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (!_repositories.ContainsKey(entityType))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(entityType, repository);
            }

            return (IGenericRepository<TEntity>)_repositories[entityType];
        }

        public IProgramCategoryRepository ProgramCategories => 
            _programCategoryRepository ??= new ProgramCategoryRepository(_context);

        public ISupportProgramRepository SupportPrograms => 
            _supportProgramRepository ??= new SupportProgramRepository(_context);

        public IUserProgramRepository UserPrograms => 
            _userProgramRepository ??= new UserProgramRepository(_context);

        public IUserAccountRepository UserAccounts => 
            _userAccountRepository ??= new UserAccountRepository(_context);

        public IPsychologistRepository Psychologists => 
            _psychologistRepository ??= new PsychologistRepository(_context);

        public IAppointmentRepository Appointments => 
            _appointmentRepository ??= new AppointmentRepository(_context);

        public IBlogRepository Blogs => 
            _blogRepository ??= new BlogRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using MentalEdu.Repositories.Repositories;
using MentalEdu.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MentalEdu.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<MentalEduContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(MentalEduContext).Assembly.FullName)));

            // Register repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProgramCategoryRepository, ProgramCategoryRepository>();
            services.AddScoped<ISupportProgramRepository, SupportProgramRepository>();
            services.AddScoped<IUserProgramRepository, UserProgramRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IPsychologistRepository, PsychologistRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            // Register UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
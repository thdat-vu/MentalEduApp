using MentalEdu.BlazorApp.APIServices.Components;
using MentalEdu.Repositories.UnitOfWork;
using MentalEdu.Services.Services;
using MentalEdu.Repositories.Configuration;
using DotNetEnv;

namespace MentalEdu.BlazorApp.APIServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load environment variables from .env file
            Env.Load();

            var builder = WebApplication.CreateBuilder(args);

            // Configure connection string from environment variables if needed
            if (Environment.GetEnvironmentVariable("DB_SERVER") != null)
            {
                var connectionString = $"Data Source={Environment.GetEnvironmentVariable("DB_SERVER")};" +
                                      $"Initial Catalog={Environment.GetEnvironmentVariable("DB_NAME")};" +
                                      $"Persist Security Info=True;" +
                                      $"User ID={Environment.GetEnvironmentVariable("DB_USER")};" +
                                      $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                                      $"Encrypt=False";

                builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;
            }

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Register DBContext
            builder.Services.AddDbContextConfiguration(builder.Configuration);

            // Add controllers
            builder.Services.AddControllers();

            // Register services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISupportProgramService, SupportProgramService>();
            builder.Services.AddScoped<IProgramCategoryService, ProgramCategoryService>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", 
                    builder => builder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            // Use CORS
            app.UseCors("AllowAll");

            // Map controllers
            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

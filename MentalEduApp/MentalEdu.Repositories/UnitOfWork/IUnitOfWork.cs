using MentalEdu.Repositories.Models;
using MentalEdu.Repositories.Repositories;

namespace MentalEdu.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositories
        IAppointmentRepository Appointments { get; }
        IBlogRepository Blogs { get; }
        IBlogCommentRepository BlogComments { get; }
        INotificationRepository Notifications { get; }
        IProgramCategoryRepository ProgramCategories { get; }
        IReportRepository Reports { get; }
        ISupportProgramRepository SupportPrograms { get; }
        ISurveyRepository Surveys { get; }
        ISurveyAnswerRepository SurveyAnswers { get; }
        ISurveyQuestionRepository SurveyQuestions { get; }
        IUserAccountRepository UserAccounts { get; }
        IUserProgramRepository UserPrograms { get; }

        // Save changes
        int Complete();
        Task<int> CompleteAsync();
    }
}
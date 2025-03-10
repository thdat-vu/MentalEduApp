using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Repositories;

namespace MentalEdu.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MentalEduGroupProjectContext _context;
        private bool _disposed = false;

        // Repositories
        private IAppointmentRepository _appointments;
        private IBlogRepository _blogs;
        private IBlogCommentRepository _blogComments;
        private INotificationRepository _notifications;
        private IProgramCategoryRepository _programCategories;
        private IReportRepository _reports;
        private ISupportProgramRepository _supportPrograms;
        private ISurveyRepository _surveys;
        private ISurveyAnswerRepository _surveyAnswers;
        private ISurveyQuestionRepository _surveyQuestions;
        private IUserAccountRepository _userAccounts;
        private IUserProgramRepository _userPrograms;

        public UnitOfWork(MentalEduGroupProjectContext context)
        {
            _context = context;
        }

        public IAppointmentRepository Appointments => _appointments ??= new AppointmentRepository(_context);
        public IBlogRepository Blogs => _blogs ??= new BlogRepository(_context);
        public IBlogCommentRepository BlogComments => _blogComments ??= new BlogCommentRepository(_context);
        public INotificationRepository Notifications => _notifications ??= new NotificationRepository(_context);
        public IProgramCategoryRepository ProgramCategories => _programCategories ??= new ProgramCategoryRepository(_context);
        public IReportRepository Reports => _reports ??= new ReportRepository(_context);
        public ISupportProgramRepository SupportPrograms => _supportPrograms ??= new SupportProgramRepository(_context);
        public ISurveyRepository Surveys => _surveys ??= new SurveyRepository(_context);
        public ISurveyAnswerRepository SurveyAnswers => _surveyAnswers ??= new SurveyAnswerRepository(_context);
        public ISurveyQuestionRepository SurveyQuestions => _surveyQuestions ??= new SurveyQuestionRepository(_context);
        public IUserAccountRepository UserAccounts => _userAccounts ??= new UserAccountRepository(_context);
        public IUserProgramRepository UserPrograms => _userPrograms ??= new UserProgramRepository(_context);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
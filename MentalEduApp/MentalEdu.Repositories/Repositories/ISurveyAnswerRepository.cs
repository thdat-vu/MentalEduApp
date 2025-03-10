using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface ISurveyAnswerRepository : IRepository<SurveyAnswer>
    {
        // Add specific methods for SurveyAnswer entity
        Task<IEnumerable<SurveyAnswer>> GetAnswersBySurveyIdAsync(Guid surveyId);
        Task<IEnumerable<SurveyAnswer>> GetAnswersByUserIdAsync(Guid userId);
        Task<IEnumerable<SurveyAnswer>> GetAnswersByQuestionIdAsync(Guid questionId);
    }
}
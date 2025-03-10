using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface ISurveyQuestionRepository : IRepository<SurveyQuestion>
    {
        // Add specific methods for SurveyQuestion entity
        Task<IEnumerable<SurveyQuestion>> GetQuestionsBySurveyIdAsync(Guid surveyId);
        Task<IEnumerable<SurveyQuestion>> GetQuestionsByTypeAsync(string questionType);
    }
}
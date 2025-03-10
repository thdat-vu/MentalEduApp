using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        // Add specific methods for Survey entity
        Task<IEnumerable<Survey>> GetActiveSurveysAsync();
        Task<IEnumerable<Survey>> GetSurveysByTypeAsync(string surveyType);
    }
}
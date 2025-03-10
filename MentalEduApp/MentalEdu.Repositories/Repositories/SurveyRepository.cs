using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Survey>> GetActiveSurveysAsync()
        {
            var now = DateTime.Now;
            return await _dbSet.Where(s => s.ActiveFlag == true && 
                                         s.StartDate <= now && 
                                         (s.EndDate == null || s.EndDate >= now))
                              .OrderByDescending(s => s.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Survey>> GetSurveysByTypeAsync(string surveyType)
        {
            return await _dbSet.Where(s => s.SurveyType == surveyType && s.ActiveFlag == true)
                              .OrderByDescending(s => s.CreatedAt)
                              .ToListAsync();
        }
    }
}
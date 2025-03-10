using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class SurveyQuestionRepository : Repository<SurveyQuestion>, ISurveyQuestionRepository
    {
        public SurveyQuestionRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SurveyQuestion>> GetQuestionsBySurveyIdAsync(Guid surveyId)
        {
            return await _dbSet.Where(sq => sq.SurveyId == surveyId && sq.ActiveFlag == true)
                              .OrderBy(sq => sq.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<SurveyQuestion>> GetQuestionsByTypeAsync(string questionType)
        {
            return await _dbSet.Where(sq => sq.QuestionType == questionType && sq.ActiveFlag == true)
                              .OrderBy(sq => sq.CreatedAt)
                              .ToListAsync();
        }
    }
}
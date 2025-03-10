using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class SurveyAnswerRepository : Repository<SurveyAnswer>, ISurveyAnswerRepository
    {
        public SurveyAnswerRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SurveyAnswer>> GetAnswersBySurveyIdAsync(Guid surveyId)
        {
            return await _dbSet.Where(sa => sa.SurveyId == surveyId && sa.ActiveFlag == true)
                              .OrderBy(sa => sa.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<SurveyAnswer>> GetAnswersByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(sa => sa.UserId == userId && sa.ActiveFlag == true)
                              .OrderByDescending(sa => sa.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<SurveyAnswer>> GetAnswersByQuestionIdAsync(Guid questionId)
        {
            return await _dbSet.Where(sa => sa.QuestionId == questionId && sa.ActiveFlag == true)
                              .OrderBy(sa => sa.CreatedAt)
                              .ToListAsync();
        }
    }
}
using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Report>> GetReportsByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(r => r.UserId == userId && r.ActiveFlag == true)
                              .OrderByDescending(r => r.ReportDate)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByTypeAsync(string reportType)
        {
            return await _dbSet.Where(r => r.ReportType == reportType && r.ActiveFlag == true)
                              .OrderByDescending(r => r.ReportDate)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet.Where(r => r.ReportDate >= startDate && r.ReportDate <= endDate && r.ActiveFlag == true)
                              .OrderByDescending(r => r.ReportDate)
                              .ToListAsync();
        }
    }
}
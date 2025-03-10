using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
        // Add specific methods for Report entity
        Task<IEnumerable<Report>> GetReportsByUserIdAsync(Guid userId);
        Task<IEnumerable<Report>> GetReportsByTypeAsync(string reportType);
        Task<IEnumerable<Report>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
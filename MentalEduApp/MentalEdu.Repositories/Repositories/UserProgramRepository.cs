using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class UserProgramRepository : Repository<UserProgram>, IUserProgramRepository
    {
        public UserProgramRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserProgram>> GetProgramsByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(up => up.UserId == userId && up.ActiveFlag == true)
                              .OrderByDescending(up => up.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<UserProgram>> GetUsersByProgramIdAsync(Guid programId)
        {
            return await _dbSet.Where(up => up.ProgramId == programId && up.ActiveFlag == true)
                              .OrderByDescending(up => up.CreatedAt)
                              .ToListAsync();
        }

        public async Task<IEnumerable<UserProgram>> GetProgramsByStatusAsync(string status)
        {
            return await _dbSet.Where(up => up.Status == status && up.ActiveFlag == true)
                              .OrderByDescending(up => up.CreatedAt)
                              .ToListAsync();
        }
    }
}
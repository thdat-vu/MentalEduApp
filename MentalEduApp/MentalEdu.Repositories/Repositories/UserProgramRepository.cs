using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class UserProgramRepository : GenericRepository<UserProgram>, IUserProgramRepository
    {
        private readonly MentalEduContext _dbContext;

        public UserProgramRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<UserProgram>> GetUserProgramsAsync(int userId)
        {
            return await _dbContext.UserPrograms
                .Where(up => up.UserId == userId && up.ActiveFlag == true)
                .Include(up => up.Program)
                .ToListAsync();
        }

        public async Task<UserProgram?> GetUserProgramDetailsAsync(Guid id)
        {
            return await _dbContext.UserPrograms
                .Include(up => up.Program)
                .Include(up => up.User)
                .FirstOrDefaultAsync(up => up.Id == id);
        }
    }
}
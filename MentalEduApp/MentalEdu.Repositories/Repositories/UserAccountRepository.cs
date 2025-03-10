using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class UserAccountRepository : GenericRepository<UserAccount>, IUserAccountRepository
    {
        private readonly MentalEduContext _dbContext;

        public UserAccountRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<UserAccount?> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.UserAccounts
                .FirstOrDefaultAsync(u => u.UserName == username && u.IsActive);
        }

        public async Task<UserAccount?> GetUserWithProgramsAsync(int userId)
        {
            return await _dbContext.UserAccounts
                .Include(u => u.UserPrograms)
                    .ThenInclude(up => up.Program)
                .FirstOrDefaultAsync(u => u.UserAccountId == userId && u.IsActive);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _dbContext.UserAccounts
                .AnyAsync(u => u.Email == email);
        }
    }
}
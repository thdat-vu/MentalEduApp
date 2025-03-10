using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<UserAccount> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.ActiveFlag == true);
        }

        public async Task<IEnumerable<UserAccount>> GetUsersByRoleAsync(string role)
        {
            return await _dbSet.Where(u => u.Role == role && u.ActiveFlag == true)
                              .OrderBy(u => u.FullName)
                              .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}
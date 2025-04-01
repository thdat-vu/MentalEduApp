using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(MentalEdu_ASMContext context) : base(context)
        {
        }

        public async Task<UserAccount> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.IsActive == true);
        }

        public async Task<IEnumerable<UserAccount>> GetUsersByRoleAsync(int role)
        {
            return await _dbSet.Where(u => u.RoleId == role && u.IsActive == true)
                              .OrderBy(u => u.FullName)
                              .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}
using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        // Add specific methods for UserAccount entity
        Task<UserAccount> GetByEmailAsync(string email);
        Task<IEnumerable<UserAccount>> GetUsersByRoleAsync(int role);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
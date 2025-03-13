using MentalEdu.Repositories.Models;

namespace MentalEdu.Services.Services
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccount>> GetAllUsersAsync();
        Task<UserAccount> GetUserByIdAsync(Guid id);
        Task<UserAccount> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserAccount>> GetUsersByRoleAsync(string role);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<UserAccount> CreateUserAsync(UserAccount user, string password);
        Task UpdateUserAsync(UserAccount user);
        Task DeleteUserAsync(Guid id);
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}
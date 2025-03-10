using MentalEdu.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface IUserAccountRepository : IGenericRepository<UserAccount>
    {
        Task<UserAccount?> GetUserByUsernameAsync(string username);
        Task<UserAccount?> GetUserWithProgramsAsync(int userId);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
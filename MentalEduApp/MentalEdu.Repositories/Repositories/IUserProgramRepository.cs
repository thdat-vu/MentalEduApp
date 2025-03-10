using MentalEdu.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface IUserProgramRepository : IGenericRepository<UserProgram>
    {
        Task<IEnumerable<UserProgram>> GetUserProgramsAsync(int userId);
        Task<UserProgram?> GetUserProgramDetailsAsync(Guid id);
    }
}
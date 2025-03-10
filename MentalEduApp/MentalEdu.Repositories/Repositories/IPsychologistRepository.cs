using MentalEdu.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface IPsychologistRepository : IGenericRepository<Psychologist>
    {
        Task<IEnumerable<Psychologist>> GetActivePsychologistsAsync();
        Task<Psychologist?> GetPsychologistWithSpecializationsAsync(Guid id);
        Task<IEnumerable<Psychologist>> GetPsychologistsBySpecializationAsync(Guid specializationId);
    }
}
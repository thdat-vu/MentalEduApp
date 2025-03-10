using MentalEdu.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByStudentAsync(int studentId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPsychologistAsync(Guid psychologistId);
        Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(int userId);
    }
}
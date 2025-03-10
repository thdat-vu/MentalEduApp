using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        // Add specific methods for Appointment entity
        Task<IEnumerable<Appointment>> GetAppointmentsByStudentIdAsync(Guid studentId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPsychologistIdAsync(Guid psychologistId);
        Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(Guid userId, bool isPsychologist);
    }
}
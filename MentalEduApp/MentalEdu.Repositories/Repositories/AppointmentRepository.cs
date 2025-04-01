using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MentalEdu_ASMContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByStudentIdAsync(Guid studentId)
        {
            // Convert Guid to int? or adjust the comparison based on your model
            return await _dbSet.Where(a => a.StudentId.ToString() == studentId.ToString() && a.ActiveFlag == true)
                              .OrderByDescending(a => a.AppointmentDate)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPsychologistIdAsync(Guid psychologistId)
        {
            // Convert Guid to int? or adjust the comparison based on your model
            return await _dbSet.Where(a => a.PsychologistId.ToString() == psychologistId.ToString() && a.ActiveFlag == true)
                              .OrderByDescending(a => a.AppointmentDate)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(Guid userId, bool isPsychologist)
        {
            var now = DateTime.Now;
            
            if (isPsychologist)
            {
                // Convert Guid to int? or adjust the comparison based on your model
                return await _dbSet.Where(a => a.PsychologistId.ToString() == userId.ToString() && 
                                             a.AppointmentDate > now && 
                                             a.ActiveFlag == true)
                                  .OrderBy(a => a.AppointmentDate)
                                  .ToListAsync();
            }
            else
            {
                // Convert Guid to int? or adjust the comparison based on your model
                return await _dbSet.Where(a => a.StudentId.ToString() == userId.ToString() && 
                                             a.AppointmentDate > now && 
                                             a.ActiveFlag == true)
                                  .OrderBy(a => a.AppointmentDate)
                                  .ToListAsync();
            }
        }
    }
}
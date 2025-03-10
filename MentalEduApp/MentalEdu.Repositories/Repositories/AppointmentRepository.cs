using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(MentalEduGroupProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByStudentIdAsync(Guid studentId)
        {
            return await _dbSet.Where(a => a.StudentId == studentId && a.ActiveFlag == true)
                              .OrderByDescending(a => a.AppointmentDate)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPsychologistIdAsync(Guid psychologistId)
        {
            return await _dbSet.Where(a => a.PsychologistId == psychologistId && a.ActiveFlag == true)
                              .OrderByDescending(a => a.AppointmentDate)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(Guid userId, bool isPsychologist)
        {
            var now = DateTime.Now;
            
            if (isPsychologist)
            {
                return await _dbSet.Where(a => a.PsychologistId == userId && 
                                             a.AppointmentDate > now && 
                                             a.ActiveFlag == true)
                                  .OrderBy(a => a.AppointmentDate)
                                  .ToListAsync();
            }
            else
            {
                return await _dbSet.Where(a => a.StudentId == userId && 
                                             a.AppointmentDate > now && 
                                             a.ActiveFlag == true)
                                  .OrderBy(a => a.AppointmentDate)
                                  .ToListAsync();
            }
        }
    }
}
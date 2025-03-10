using MentalEdu.Repositories.DbContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalEdu.Repositories.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly MentalEduContext _dbContext;

        public AppointmentRepository(MentalEduContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByStudentAsync(int studentId)
        {
            return await _dbContext.Appointments
                .Where(a => a.StudentId == studentId && a.ActiveFlag == true)
                .Include(a => a.Psychologist)
                    .ThenInclude(p => p.User)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPsychologistAsync(Guid psychologistId)
        {
            return await _dbContext.Appointments
                .Where(a => a.PsychologistId == psychologistId && a.ActiveFlag == true)
                .Include(a => a.Student)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(int userId)
        {
            var now = DateTime.Now;
            return await _dbContext.Appointments
                .Where(a => (a.StudentId == userId || a.Psychologist.UserId == userId) && 
                            a.AppointmentDate > now && 
                            a.ActiveFlag == true)
                .Include(a => a.Psychologist)
                    .ThenInclude(p => p.User)
                .Include(a => a.Student)
                .OrderBy(a => a.AppointmentDate)
                .ToListAsync();
        }
    }
}
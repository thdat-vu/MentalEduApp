using MentalEdu.Repositories.DBContext;
using MentalEdu.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace MentalEdu.Repositories.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly MentalEduGroupProjectContext _mentalEduContext;

        public NotificationRepository(MentalEduGroupProjectContext context) : base(context)
        {
            _mentalEduContext = context;
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(Guid userId)
        {
            return await _dbSet.Where(n => n.UserId == userId && n.IsRead == false && n.ActiveFlag == true)
                              .OrderByDescending(n => n.CreatedAt)
                              .ToListAsync();
        }

        public async Task<int> MarkAsReadAsync(Guid notificationId)
        {
            var notification = await _dbSet.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                notification.UpdatedAt = DateTime.Now;
                return await _mentalEduContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> MarkAllAsReadAsync(Guid userId)
        {
            var notifications = await _dbSet.Where(n => n.UserId == userId && n.IsRead == false && n.ActiveFlag == true)
                                          .ToListAsync();
            
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
                notification.UpdatedAt = DateTime.Now;
            }
            
            return await _mentalEduContext.SaveChangesAsync();
        }
    }
}
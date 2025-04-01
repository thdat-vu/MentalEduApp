using MentalEdu.Repositories.Models;

namespace MentalEdu.Repositories.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        // Add specific methods for Notification entity
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId);
        Task<int> MarkAsReadAsync(Guid notificationId);
        Task<int> MarkAllAsReadAsync(int userId);
    }
}
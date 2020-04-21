using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<Notification> GetUserNotifications(int userid);
        UserNotification GetUserSpecificNotification(int userid, int notificationId);
    }
}
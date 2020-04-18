using GamersGridApp.Models;
using System.Collections.Generic;

namespace GamersGridApp.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<Notification> GetUserNotifications(int userid);
    }
}
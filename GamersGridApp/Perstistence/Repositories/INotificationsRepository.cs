using GamersGridApp.Models;
using System.Collections.Generic;

namespace GamersGridApp.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetUnreadNoficationsForOneUser(int userId);
    }
}
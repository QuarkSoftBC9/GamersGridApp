using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetUnreadNoficationsForOneUser(int userId);
    }
}
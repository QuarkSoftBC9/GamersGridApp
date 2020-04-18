using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.Repositories
{
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetUnreadNoficationsForOneUser(int userId)
        {
            return _context.UserNotifications
                   .Where(u => u.UserId == userId && !u.IsRead)
                   //.Include(un => un.Notification)
                   .Select(un => un.Notification)
                   .ToList();
        }
    }
}
using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class UserNotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetUserNotifications(int userid)
        {
            return _context.UserNotifications
                          .Where(un => un.UserId == userid && !un.IsRead)
                          .Include(un => un.Notification)
                          .Select(n => n.Notification)
                          .ToList();
        }
    }
}
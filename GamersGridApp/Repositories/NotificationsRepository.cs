using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class NotificationsRepository
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
﻿using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
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

        public UserNotification GetUserSpecificNotification(int userid, int notificationId)
        {
            return _context.UserNotifications
                .SingleOrDefault(un => un.NotificationId == notificationId && un.UserId == userid);
        }
    }
}
using GamersGridApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamersGridApp.Controllers.api
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<Notification> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.Users
               .Where(u => u.Id == userId)
               .Select(n => n.UserAccount.UserNotifications)
               .SingleOrDefault()
               .Select(n => n.Notification);
               
              
               

            return notifications;

        }
    }
}

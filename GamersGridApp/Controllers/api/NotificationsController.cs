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

        public IEnumerable<UserNotification> GetNotifications()
        {

            var userId = User.Identity.GetUserId();

            if (!string.IsNullOrWhiteSpace(userId))
            {
                var existingperson = context.Users
         .Single(u => u.Id == userId);

                var usernotifications = context.UserNotifications
                       .Where(u => u.UserId == existingperson.UserId)
                       .ToList();


                return usernotifications;
            }
            else
            {
                return null;
            }

                


            
            
             
            


        }
    }
}

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

        public IHttpActionResult GetNotifications()
        {

            var userId = User.Identity.GetUserId();

            //var user = context.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).Single();


            //    var userNotifications = context.UserNotifications
            //           .Where(u => u.UserId == user.ID && !u.IsRead)
            //           .Include(un => un.Notification)
            //           .Select( un=> un.Notification)
            //           .ToList();

            return Ok();


        }
    }
}

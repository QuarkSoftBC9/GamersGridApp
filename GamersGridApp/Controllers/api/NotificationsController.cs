
using GamersGridApp.Core;
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
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork UnitOfWork;
        public NotificationsController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }



        public IHttpActionResult GetNotifications()
        {

            var userId = User.Identity.GetUserId();

            //var user = context.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).Single();
            var user = UnitOfWork.GGUsers.GetLoggedUser(userId);

            //var userNotifications = context.UserNotifications
            //       .Where(u => u.UserId == user.ID && !u.IsRead)
            //       .Include(un => un.Notification)
            //       .Select(un => un.Notification)
            //       .ToList();

            var userNotifications = UnitOfWork.UserNotifications.GetUserNotifications(user.ID);

            return Ok(userNotifications);


        }
    }
}

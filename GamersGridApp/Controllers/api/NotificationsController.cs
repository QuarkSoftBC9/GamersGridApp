using GamersGridApp.Models;
using GamersGridApp.Repositories;
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
        private ApplicationDbContext context;
        private readonly GameRepository gameRepository;
        private readonly UserGameRepository userGameRelationsRepository;
        private readonly UserRepository userRepository;
        private readonly FollowsRepository followsRepository;
        private readonly UserNotificationRepository userNotificationRepository;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
            gameRepository = new GameRepository(context);
            userGameRelationsRepository = new UserGameRepository(context);
            userRepository = new UserRepository(context);
            followsRepository = new FollowsRepository(context);
            userNotificationRepository = new UserNotificationRepository(context);
        }

        public IHttpActionResult GetNotifications()
        {

            var userId = User.Identity.GetUserId();

            //var user = context.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).Single();
            var user = userRepository.GetLoggedUser(userId);

            //var userNotifications = context.UserNotifications
            //       .Where(u => u.UserId == user.ID && !u.IsRead)
            //       .Include(un => un.Notification)
            //       .Select(un => un.Notification)
            //       .ToList();

            var userNotifications = userNotificationRepository.GetUserNotifications(user.ID);

            return Ok(userNotifications);


        }
    }
}

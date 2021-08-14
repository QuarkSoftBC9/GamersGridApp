using GamersGrid.BLL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {

        private readonly SignInManager<GGuser> _signInManager;
        private readonly UserManager<GGuser> _userManager;
        private readonly ILogger<FollowsController> _logger;
        private readonly IUnitOfWork unitOfWork;


        public FollowsController(ILogger<FollowsController> logger,
            SignInManager<GGuser> signInManager,
            UserManager<GGuser> userManager,
            IUnitOfWork workUnit)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            unitOfWork = workUnit;
        }



        [HttpGet]
        public async Task<IActionResult> CheckRelation(int followerId, int followeeId)
        {

            var followRelation1 =await unitOfWork.FollowRelations.GetFollowRelationOfTwoUsers(followerId, followeeId);

            var followRelation2 = await unitOfWork.FollowRelations.GetFollowRelationOfTwoUsers(followeeId, followerId);

            if (followRelation1 == null || followRelation2 == null)
                return BadRequest("no mutual relation");
            else
                return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Follow([FromForm]FollowsDto followDto)
        {

            // if not, a new follow gets created
            FollowRelation newFollow = new FollowRelation(followDto.FolloweeId, followDto.FollowerId);

            try //Create the realation in db
            {
                //dbContext.Follows.Add(newFollow);
                unitOfWork.FollowRelations.Add(newFollow);
                await unitOfWork.Save();
            }
            catch (Exception e)//Case that userId and followerId inside dto are incorrect
            {
                return BadRequest(e.Message);
            }
            finally
            {
                //var follower = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FollowerId);
                //var follower = unitOfWork.GGUsers.GetUser(followDto.FollowerId);

                ////var followee = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FolloweeId);
                //var followee = unitOfWork.GGUsers.GetUser(followDto.FolloweeId);

                // Creating the personalized Message for followee
                //var personalNotification = Notification.FollowPersonal(follower);
                //followee.Notify(personalNotification);

                ////Creating the list of users with mutual follows with the 2 interacting users
                //var usersToNotifyBuffer = unitOfWork.GGUsers.GetFollowersOfTwoUsersWithTheirFollowees(followee.ID, follower.ID);

                //var usersToNotify = new List<User>();

                //foreach (var user in usersToNotifyBuffer)
                //{
                //    bool condition1 = user.Followees.Contains(new Follow(user.ID, followee.ID));
                //    bool condition2 = user.Followees.Contains(new Follow(user.ID, follower.ID));
                //    bool condition3 = user.ID == followee.ID;

                //    if (condition1 && condition2 && !condition3)
                //        usersToNotify.Add(user);
                //}

                //var notification = Notification.Follow(followee, follower);
                //if (usersToNotify.Count != 0)
                //{
                //    foreach (var user in usersToNotify)
                //    {   //Notify all Users
                //        user.Notify(notification);
                //    }
                //}

                //Write Notifications in Db
                //dbContext.SaveChanges();
                //UnitOfWork.Complete();


                //signlar logic start
                //NotificationsHub notificationsHub = new NotificationsHub();
                //notificationsHub.SendNotification(usersToNotify, notification);
                //notificationsHub.SendNotificationPersonal(followee, personalNotification);
            }

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> UnFollow([FromForm]FollowsDto followDto)
        {
            //checking for existing relation in db

            FollowRelation existingFollowInDb = await unitOfWork.FollowRelations.GetFollowRelationOfTwoUsersIncludingUser(followDto.FolloweeId, followDto.FollowerId);


            // if yes
            try
            {
                unitOfWork.FollowRelations.Remove(existingFollowInDb);
                await unitOfWork.Save();

            }
            catch //Case that userId and followerId inside dto are incorrect
            {
                return BadRequest();
            }
            finally
            {

                //var follower = unitOfWork.GGUsers.GetUser(followDto.FollowerId);
                //var followee = unitOfWork.GGUsers.GetUser(followDto.FolloweeId);

                //// Creating the personalized Message for followee
                //var notificationPersonal = Notification.UnfollowPersonal(follower);
                //followee.Notify(notificationPersonal);

                ////Creating the list of users with mutual follows with the 2 interacting users
                //var usersToNotifyBuffer = UnitOfWork.GGUsers.GetFollowersOfTwoUsersWithTheirFollowees(followee.ID, follower.ID);

                //var usersToNotify = new List<User>();


                //foreach (var user in usersToNotifyBuffer)
                //{
                //    bool condition1 = user.Followees.Contains(new Follow(user.ID, followee.ID));
                //    bool condition2 = user.Followees.Contains(new Follow(user.ID, follower.ID));
                //    bool condition3 = user.ID == followee.ID;

                //    if (!condition1 && !condition2 && !condition3)
                //        usersToNotify.Add(user);
                //}

                //var notification = Notification.Unfollow(followee, follower);
                //if (usersToNotify.Count != 0)
                //{
                //    foreach (var user in usersToNotify)
                //    {   //Notify all Users
                //        user.Notify(notification);
                //    }
                //}


                ////Write Notifications in Db
                //UnitOfWork.Complete();
                ////NotificationsHub notificationsHub = new NotificationsHub();
                ////notificationsHub.SendNotification(usersToNotify, notification);
                ////notificationsHub.SendNotificationPersonal(followee, notificationPersonal);

            }

            return Ok();
        }
    }
}

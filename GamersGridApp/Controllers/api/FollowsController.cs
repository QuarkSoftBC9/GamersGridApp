
using GamersGridApp.Core;
using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Core.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamersGridApp.Controllers.api
{
    public class FollowsController : ApiController
    {

        private readonly IUnitOfWork UnitOfWork;


        public FollowsController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }


        [HttpGet]
        public IHttpActionResult CheckRelation(int followerId, int followeeId)
        {
           
            var followRelation1 = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(followerId, followeeId);

            var followRelation2 = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(followeeId, followerId);

            if (followRelation1 == null || followRelation2 == null)
                return BadRequest("no mutual relation");
            else
                return Ok();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto followDto)
        {

            // if not, a new follow gets created
            Follow newFollow = new Follow(followDto.FolloweeId, followDto.FollowerId);

            try //Create the realation in db
            {
                //dbContext.Follows.Add(newFollow);
                UnitOfWork.Follows.Add(newFollow);
                UnitOfWork.Complete();
            }
            catch (Exception e)//Case that userId and followerId inside dto are incorrect
            {
                return BadRequest(e.Message);
            }
            finally 
            {
                //var follower = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FollowerId);
                var follower = UnitOfWork.GGUsers.GetUser(followDto.FollowerId);

                //var followee = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FolloweeId);
                var followee = UnitOfWork.GGUsers.GetUser(followDto.FolloweeId);

                // Creating the personalized Message for followee
                followee.Notify(Notification.FollowPersonal(follower));

                //Creating the list of users with mutual follows with the 2 interacting users
                var usersToNotifyBuffer = UnitOfWork.GGUsers.GetFollowersOfTwoUsersWithTheirFollowees(followee.ID, follower.ID);

                var usersToNotify = new List<User>();

                foreach (var user in usersToNotifyBuffer)
                {
                    bool condition1 = user.Followees.Contains(new Follow(user.ID, followee.ID));
                    bool condition2 = user.Followees.Contains(new Follow(user.ID, follower.ID));
                    bool condition3 = user.ID == followee.ID;

                    if (condition1 && condition2 && !condition3)
                        usersToNotify.Add(user);
                }


                if (usersToNotify.Count != 0)
                {
                    var notification = Notification.Follow(followee, follower);
                    foreach (var user in usersToNotify)
                    {   //Notify all Users
                        user.Notify(notification);
                    }
                }

                //Write Notifications in Db
                //dbContext.SaveChanges();
                UnitOfWork.Complete();

            }

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult UnFollow(FollowsDto followDto)
        {
            //checking for existing relation in db
     
            Follow existingFollowInDb = UnitOfWork.Follows.GetFollowRelationOfTwoUsersIncludingUser(followDto.FolloweeId, followDto.FollowerId);


            // if yes
            try 
            {
                UnitOfWork.Follows.Remove(existingFollowInDb);
                UnitOfWork.Complete();

            }
            catch //Case that userId and followerId inside dto are incorrect
            {
                return BadRequest();
            }
            finally
            {

                var follower = UnitOfWork.GGUsers.GetUser(followDto.FollowerId);
                var followee = UnitOfWork.GGUsers.GetUser(followDto.FolloweeId);

                // Creating the personalized Message for followee
                followee.Notify(Notification.UnfollowPersonal(follower));

                //Creating the list of users with mutual follows with the 2 interacting users
                var usersToNotifyBuffer =  UnitOfWork.GGUsers.GetFollowersOfTwoUsersWithTheirFollowees(followee.ID, follower.ID);

                var usersToNotify = new List<User>();


                foreach (var user in usersToNotifyBuffer)
                {
                    bool condition1 = user.Followees.Contains(new Follow(user.ID, followee.ID));
                    bool condition2 = user.Followees.Contains(new Follow(user.ID, follower.ID));
                    bool condition3 = user.ID == followee.ID;

                    if (!condition1 && !condition2 && !condition3)
                        usersToNotify.Add(user);
                }


                if (usersToNotify.Count != 0)
                {
                    var notification = Notification.Unfollow(followee, follower);
                    foreach (var user in usersToNotify)
                    {   //Notify all Users
                        user.Notify(notification);
                    }
                }


                //Write Notifications in Db
                UnitOfWork.Complete();

            }

            return Ok();
        }
    }
}

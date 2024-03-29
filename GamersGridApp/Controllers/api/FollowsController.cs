﻿using GamersGridApp.Dtos;
using GamersGridApp.Enums;
using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace GamersGridApp.Controllers.api
{
    public class FollowsController : ApiController
    {
        private ApplicationDbContext dbContext;

        public FollowsController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult FindMutualFollowers()
        {
            var userId = User.Identity.GetUserId();
            var dev = dbContext.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).FirstOrDefault();

            var users = dbContext.GamersGridUsers.Where(g => g.Followers.Any(fo => fo.FollowerId == dev.ID) && g.Followees.Any(fo => fo.UserId == dev.ID)).ToList();
            return Ok(users);
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto followDto)
        {
            //checking for existing relation in db
            Follow existingFollowInDb = dbContext.Follows
                          .Include(f => f.User)
                          .SingleOrDefault(f => f.User.ID == followDto.FolloweeId && f.FollowerId == followDto.FollowerId);

          

            // if not, a new follow gets created
            Follow newFollow = new Follow(followDto.FolloweeId, followDto.FollowerId);

            try //Create the realation in db
            {
                dbContext.Follows.Add(newFollow);
                dbContext.SaveChanges();
            }
            catch //Case that userId and followerId inside dto are incorrect
            {
                return BadRequest();
            }
            finally 
            {
                var follower = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FollowerId);
                var followee = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FolloweeId);

                // Creating the personalized Message for followee
                followee.Notify(Notification.FollowPersonal(follower));

                //Creating the list of users with mutual follows with the 2 interacting users
                var usersToNotifyBuffer = dbContext.Follows
                    .Include(f => f.Follower)
                    .Include(f => f.User)
                    .Where(f => f.UserId == followee.ID || f.UserId == follower.ID)
                    .Select(f => f.Follower)
                    .Distinct()
                    .Include(u => u.Followees)
                    .ToList();

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
                    foreach (var user in usersToNotify)
                    {   //Notify all Users
                        user.Notify(Notification.Follow(followee, follower));
                    }
                }

                //Write Notifications in Db
                dbContext.SaveChanges();
                
            }

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult UnFollow(FollowsDto followDto)
        {
            //checking for existing relation in db
            Follow existingFollowInDb = dbContext.Follows
                          .Include(f => f.User)
                          .SingleOrDefault(f => f.User.ID == followDto.FolloweeId && f.FollowerId == followDto.FollowerId);

       

            // if yes
            try 
            {
                dbContext.Follows.Remove(existingFollowInDb);
                dbContext.SaveChanges();
            }
            catch //Case that userId and followerId inside dto are incorrect
            {
                return BadRequest();
            }
            finally
            {
                var follower = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FollowerId);
                var followee = dbContext.GamersGridUsers.Single(u => u.ID == followDto.FolloweeId);

                // Creating the personalized Message for followee
                followee.Notify(Notification.UnfollowPersonal(follower));

                //Creating the list of users with mutual follows with the 2 interacting users
                var usersToNotifyBuffer = dbContext.Follows
                    .Include(f => f.Follower)
                    .Include(f => f.User)
                    .Where(f => f.UserId == followee.ID || f.UserId == follower.ID)
                    .Select(f => f.Follower)
                    .Include(u => u.Followees)
                    .ToList();

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
                    foreach (var user in usersToNotify)
                    {   //Notify all Users
                        user.Notify(Notification.Unfollow(followee, follower));
                    }
                }


                //Write Notifications in Db
                dbContext.SaveChanges();

            }

            return Ok();
        }
    }
}

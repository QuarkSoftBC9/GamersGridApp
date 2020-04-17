﻿using GamersGridApp.Dtos;
using GamersGridApp.Enums;
using GamersGridApp.Models;
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
        private ApplicationDbContext dbContext;

        public FollowsController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult CheckRelation(int followerId, int followeeId)
        {
            var followRelation1 = dbContext.Follows
                                   .SingleOrDefault(f => f.FollowerId == followerId && f.UserId == followeeId);

            var followRelation2 = dbContext.Follows
                             .SingleOrDefault(f => f.FollowerId == followeeId && f.UserId == followerId);

            if (followRelation1 == null || followRelation2 == null)
                return BadRequest("no mutual relation");
            else
                return Ok();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto followDto)
        {
            //checking for existing relation in db
            //Follow existingFollowInDb = dbContext.Follows
            //              .Include(f => f.User)
            //              .SingleOrDefault(f => f.User.ID == followDto.FolloweeId && f.FollowerId == followDto.FollowerId);


          

            // if not, a new follow gets created
            Follow newFollow = new Follow(followDto.FolloweeId, followDto.FollowerId);

            try //Create the realation in db
            {
                dbContext.Follows.Add(newFollow);
                dbContext.SaveChanges();
            }
            catch (Exception e)//Case that userId and followerId inside dto are incorrect
            {
                return BadRequest(e.Message);
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
        //[HttpGet] 
        //public int GetFollowers(int id)
        //{
        //    var userfollowers = dbContext.Follows.Where(u => u.UserId == id).ToList().Count;
        //    return userfollowers;
        //}
    }
}

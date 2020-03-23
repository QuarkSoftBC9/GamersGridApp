using GamersGridApp.Dtos;
using GamersGridApp.Enums;
using GamersGridApp.Models;
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

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto followDto)
        {
            Follow newFollow = new Follow()
            {
                UserId = followDto.FolloweeId,
                FollowerId = followDto.FollowerId
            };


            dbContext.Follows.Add(newFollow);
            var notification = new Notification() {  UserId = followDto.FollowerId, TimeStamp = DateTime.Now, Type = NotificationType.Followed };
            dbContext.UserNotifications.Add(new UserNotification() { UserId = followDto.FolloweeId, Notification = notification});

            try
            {
                dbContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IHttpActionResult UnFollow(FollowsDto followDto)
        {
            Follow follow = new Follow()
            {
                UserId = followDto.FolloweeId,
                FollowerId = followDto.FollowerId
            };

            var dbFollow = dbContext.Follows.SingleOrDefault(f => f.UserId == followDto.FolloweeId && f.FollowerId == followDto.FollowerId);

            try
            {
                dbContext.Follows.Remove(dbFollow);
                dbContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

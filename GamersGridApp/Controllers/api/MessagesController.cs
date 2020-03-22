using GamersGridApp.Dtos;
using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace GamersGridApp.Controllers.api
{
    public class MessagesController : ApiController
    {
        private ApplicationDbContext db;
        public MessagesController()
        {
            db = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult CheckRelation(int followeeId, int followerId)
        {
            var followRelation1 = db.Follows
                                   .SingleOrDefault(f => f.FollowerId == followerId && f.UserId == followeeId);

            var followRelation2 = db.Follows
                             .SingleOrDefault(f => f.FollowerId == followeeId && f.UserId == followerId);

            if (followRelation1 == null || followRelation2 == null)
                return BadRequest();
            else
                return Ok();
        }
    }
}

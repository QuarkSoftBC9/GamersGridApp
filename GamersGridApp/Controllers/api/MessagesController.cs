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
        public IHttpActionResult CheckRelation(int loggeduser, int user)
        {
            var followRelation1 = db.Follows
                                   .SingleOrDefault(f => f.FollowerId == loggeduser && f.UserId == user);

            var followRelation2 = db.Follows
                             .SingleOrDefault(f => f.FollowerId == user && f.UserId == loggeduser);

            if (followRelation1 == null || followRelation2 == null)
                return BadRequest();
            else
                return Ok();
        }
    }
}

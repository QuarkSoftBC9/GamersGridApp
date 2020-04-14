using GamersGridApp.Dtos;
using GamersGridApp.Models;
using Microsoft.AspNet.Identity;
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
        public IHttpActionResult FindMutualFollowers()
        {
            var userId = User.Identity.GetUserId();
            var dev = db.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).FirstOrDefault();

            var users = db.GamersGridUsers.Where(g => g.Followees.Select(fo => fo.FollowerId).Contains(dev.ID) && g.Followers.Select(fo => fo.UserId).Contains(dev.ID)).ToList();
            return Ok(users);
        }

        //[HttpGet]
        //public IHttpActionResult FindMessageChats(int ID)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var gguser = db.Users.Select(u=>u.UserAccount).FirstOrDefault(u => u.ID == ID);

        //    // var messageChats = db.Users.Where(u => u.Id == userId).Select(u => u.UserAccount.MessageChatUsers.Where(m => db.MessageChatUsers.Where());
        //    var messageChats = db.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == ID)).Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == gguser.ID)).ToList();


        //    return Ok(messageChats);
        //}
    }
}

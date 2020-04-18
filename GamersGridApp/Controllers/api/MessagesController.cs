
using GamersGridApp.Core;
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

        private readonly IUnitOfWork UnitOfWork;

        public MessagesController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }
    



        [HttpGet]
        public IHttpActionResult FindMutualFollowers()
        {
            var userId = User.Identity.GetUserId();
            //var dev = context.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).FirstOrDefault();
            var dev = UnitOfWork.GGUsers.GetLoggedUser(userId);

            //var users = context.GamersGridUsers.Where(g => g.Followers.Select(fo => fo.FollowerId).Contains(dev.ID) && g.Followees.Select(fo => fo.UserId).Contains(dev.ID)).ToList();

            var users = UnitOfWork.Follows.GetMessageUsersRelation(dev.ID);

            return Ok(users);
        }

        //[HttpGet]
        //public IHttpActionResult FindMessageChats(int ID)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var gguser = db.Users.Select(u => u.UserAccount).FirstOrDefault(u => u.ID == ID);

        //    // var messageChats = db.Users.Where(u => u.Id == userId).Select(u => u.UserAccount.MessageChatUsers.Where(m => db.MessageChatUsers.Where());
        //    var messageChats = db.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == ID)).Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == gguser.ID)).ToList();


        //    return Ok(messageChats);
        //}
    }
}

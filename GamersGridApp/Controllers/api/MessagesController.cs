using GamersGridApp.Dtos;
using GamersGridApp.Models;
using GamersGridApp.Perstistence;
using GamersGridApp.Repositories;
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
        private ApplicationDbContext context;
        private readonly GameRepository gameRepository;
        private readonly UserGameRepository userGameRelationsRepository;
        private readonly UserRepository userRepository;
        private readonly FollowsRepository followsRepository;
        private readonly UnitOfWork unitOfWork;

        public MessagesController()
        {
            context = new ApplicationDbContext();
            gameRepository = new GameRepository(context);
            userGameRelationsRepository = new UserGameRepository(context);
            userRepository = new UserRepository(context);
            unitOfWork = new UnitOfWork(context);
            followsRepository = new FollowsRepository(context);
        }
    



        [HttpGet]
        public IHttpActionResult FindMutualFollowers()
        {
            var userId = User.Identity.GetUserId();
            //var dev = context.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).FirstOrDefault();
            var dev = userRepository.GetLoggedUser(userId);

            //var users = context.GamersGridUsers.Where(g => g.Followers.Select(fo => fo.FollowerId).Contains(dev.ID) && g.Followees.Select(fo => fo.UserId).Contains(dev.ID)).ToList();

            var users = followsRepository.GetMessageUsersRelation(dev.ID);

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

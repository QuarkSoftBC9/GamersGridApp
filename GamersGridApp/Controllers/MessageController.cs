using GamersGridApp.Models;
using GamersGridApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace GamersGridApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        // GET: Message
        private ApplicationDbContext db = new ApplicationDbContext();
        //var currentUser = db.Users.Where(u => u.Id == CurrentUserID).SingleOrDefault();

        public ActionResult MessageBoard()
        {
            var CurrentUserID = User.Identity.GetUserId();
            var currentUser = db.Users.Where(u =>u.Id==CurrentUserID).Select(u=>u.UserAccount).SingleOrDefault();
            var messageChats = db.MessageChats
                .Include(m => m.Users)
                .Include(m => m.ChatHistory)
                .Where(m => m.Users.Contains(db.Users.Where(u => u.Id == CurrentUserID).Select(u => u.UserAccount).FirstOrDefault()))
                .ToList();

            var currentChat = messageChats.Take(1).SingleOrDefault();

            var viewmodel = new MessageBoardViewModel
            {
                MessageChats = messageChats,
                CurrentUserNickName = currentUser.NickName,
                CurrentChatID = currentChat.ID
            };


            return View(viewmodel);
        }

        public ActionResult GetPartial(string chatId)
        {
            int id = int.Parse(chatId);
            var aspNetUserId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == aspNetUserId).Select(u => u.UserAccount).SingleOrDefault();

            var viewModel = new MessageBoardViewModel()
            {
                CurrentChatID = id,
                CurrentUserNickName = user.NickName,
                MessageChats = db.MessageChats
                       .Include( c => c.ChatHistory)
                       .Include(m => m.Users)
                       .Where(m => m.ID == id)
                       .ToList()
            };

            return PartialView("_ChatBox", viewModel);
        }

   
        public ActionResult ChatWith(int id, int userId)
        {


            var currentGGuser = db.GamersGridUsers.SingleOrDefault(u => u.ID == id);
            var requestedGGuser = db.GamersGridUsers.SingleOrDefault(u => u.ID == userId);


            var messageChats = db.MessageChats
                .Include(m => m.Users)
                .Include(m => m.ChatHistory)
                .Where(m => m.Users.Contains(db.GamersGridUsers.FirstOrDefault(u => u.ID == id)))
                .ToList();

            var requestedChatId = messageChats
                         .Where(c => c.Users.Contains(currentGGuser))
                         .Where(c => c.Users.Contains(requestedGGuser))
                         .Select( c => c.ID)
                         .FirstOrDefault();
                
            
            if(requestedChatId == 0)
            {
                var newMessageChat = new MessageChat()
                {
                    Name = requestedGGuser.NickName,
                    Users = new List<User>() { currentGGuser, requestedGGuser },
                    ChatHistory = new List<Message>()
                };

                db.MessageChats.Add(newMessageChat);
                db.SaveChanges();

                requestedChatId = db.MessageChats
                    .Where(c => c.Users.Contains(db.GamersGridUsers.FirstOrDefault(u => u.ID == id)))
                    .Where(c => c.Users.Contains(db.GamersGridUsers.FirstOrDefault(u => u.ID == userId)))
                    .Select(m => m.ID)
                    .Single();

                messageChats = db.MessageChats
                .Include(m => m.Users)
                .Include(m => m.ChatHistory)
                .Where(m => m.Users.Contains(db.GamersGridUsers.FirstOrDefault(u => u.ID == id)))
                .ToList();

            }


            var viewModel = new MessageBoardViewModel()
            {
                CurrentChatID = requestedChatId,
                CurrentUserNickName = currentGGuser.NickName,
                MessageChats = messageChats
            };

            return View("MessageBoard", viewModel);
        }
    }
}
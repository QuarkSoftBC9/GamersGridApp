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
            var currentUser = db.Users.Where(u => u.Id == CurrentUserID).Select(u => u.UserAccount).SingleOrDefault();
            var messageChats = db.MessageChats
                .Where(mc => mc.MessageChatUsers.Contains(db.MessageChatUsers.Where(mcu => mcu.UserId == currentUser.ID).FirstOrDefault()))
                .Include(c => c.ChatHistory)
                .ToList();

            if (messageChats.Count != 0)
            {
                var currentChat = messageChats.FirstOrDefault();
                var viewmodel = new MessageBoardViewModel(messageChats, currentChat.ID, currentUser.NickName);
                return View(viewmodel);
            }
            else
            {
                var viewmodel = new MessageBoardViewModel(null, null, currentUser.NickName);
                return View(viewmodel);
            }


        }

        public ActionResult GetPartial(string chatId)
        {
            int id = int.Parse(chatId);
            var aspNetUserId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == aspNetUserId).Select(u => u.UserAccount).SingleOrDefault();
            var messageChats = db.MessageChatUsers
                         .Where(mcu => mcu.UserId == user.ID)
                         .Include(mcu => mcu.Chat)
                         .Select(mcu => mcu.Chat)
                         .Include(c => c.ChatHistory)
                         .ToList();

            var viewModel = new MessageBoardViewModel(messageChats, id, user.NickName);


            return PartialView("_ChatBox", viewModel);
        }


        public ActionResult ChatWith(int id, int userId)
        {


            var currentGGuser = db.GamersGridUsers.SingleOrDefault(u => u.ID == id);
            var requestedGGuser = db.GamersGridUsers.SingleOrDefault(u => u.ID == userId);


            var messageChatsUsersBoth = db.MessageChatUsers.Where(mcu => mcu.UserId == currentGGuser.ID || mcu.UserId == requestedGGuser.ID).Include(mcu => mcu.Chat).ToList();


            var messageChats = db.MessageChatUsers.Where(mcu => mcu.UserId == currentGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();
            var messageChatsOfRequestedUser = db.MessageChatUsers.Where(mcu => mcu.UserId == requestedGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();


            int requestedChatId = 0;

            foreach (var messageChat in messageChats)
            {
                foreach (var messageChat2 in messageChatsOfRequestedUser)
                {
                    if (messageChat.ID == messageChat2.ID && messageChat.MessageChatUsers.Count == 2)
                    {
                        requestedChatId = messageChat.ID;
                        break;
                    }
                }
            }





            if (requestedChatId == 0)
            {
                var newMessageChat = new MessageChat()
                {
                    Name = requestedGGuser.NickName,
                    MessageChatUsers = new List<MessageChatUser>(),
                    ChatHistory = new List<Message>()
                };

                var messageChatUser1 = new MessageChatUser()
                {
                    User = currentGGuser,
                    Chat = newMessageChat
                };

                var messageChatUser2 = new MessageChatUser()
                {
                    User = requestedGGuser,
                    Chat = newMessageChat
                };

                db.MessageChatUsers.Add(messageChatUser1);
                db.MessageChatUsers.Add(messageChatUser2);
                db.MessageChats.Add(newMessageChat);
                db.SaveChanges();

                messageChats = db.MessageChatUsers.Where(mcu => mcu.UserId == currentGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();
                messageChatsOfRequestedUser = db.MessageChatUsers.Where(mcu => mcu.UserId == requestedGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();

                foreach (var messageChat in messageChats)
                {
                    foreach (var messageChat2 in messageChatsOfRequestedUser)
                    {
                        if (messageChat.ID == messageChat2.ID && messageChat.MessageChatUsers.Count == 2)
                        {
                            requestedChatId = messageChat.ID;
                            break;
                        }
                    }
                }

            }


            MessageBoardViewModel viewModel = new MessageBoardViewModel(messageChats, requestedChatId, currentGGuser.NickName);


            return View("MessageBoard", viewModel);
        }
    }
}
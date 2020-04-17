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
                .Where(mc => mc.MessageChatUsers.Select(mcu=>mcu.UserId).Any(u=>u.Equals(currentUser.ID)))
                .Include(c => c.ChatHistory.Select(ch=>ch.User))
                .Include(mc=>mc.MessageChatUsers.Select(mcu=>mcu.User))
                .ToList();

            if (messageChats.Count != 0)
            {
                var currentChat = messageChats.FirstOrDefault();
                var viewmodel = new MessageBoardViewModel(messageChats, currentChat.ID, currentUser.NickName);
                return View(viewmodel);
            }
            else
            {
                var viewmodel = new MessageBoardViewModel(new List<MessageChat>(), null, currentUser.NickName);
                return View(viewmodel);
            }


        }

        [HttpGet]
        public ActionResult FindMessageChats(int ID)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).SingleOrDefault();
            var RequestedUser = db.Users.Select(u => u.UserAccount).FirstOrDefault(u => u.ID == ID);
            
            var messageChat = db.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == user.ID))
            .Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == RequestedUser.ID))
            .Where(m => m.MessageChatUsers.Count == 2)
            .Include(c=>c.ChatHistory.Select(ch=>ch.User))
            .Include(c=>c.MessageChatUsers).FirstOrDefault();

            if(messageChat==null)
            {
                var newMessageChat = new MessageChat()
                {
                    Name = RequestedUser.NickName,
                    MessageChatUsers = new List<MessageChatUser>(),
                    ChatHistory = new List<Message>()
                };

                var messageChatUser1 = new MessageChatUser()
                {
                    User = user,
                    Chat = newMessageChat
                };

                var messageChatUser2 = new MessageChatUser()
                {
                    User = RequestedUser,
                    Chat = newMessageChat
                };

                //db.MessageChatUsers.Add(messageChatUser1);
                //db.MessageChatUsers.Add(messageChatUser2);
                newMessageChat.MessageChatUsers.Add(messageChatUser1);
                newMessageChat.MessageChatUsers.Add(messageChatUser1);

                db.MessageChats.Add(newMessageChat);
                db.SaveChanges();

                 messageChat = db.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == user.ID))
                            .Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == RequestedUser.ID))
                            .Where(m => m.MessageChatUsers.Count == 2)
                            .Include(c => c.ChatHistory.Select(ch => ch.User))
                            .Include(c => c.MessageChatUsers).FirstOrDefault();

            }
            var viewModel = new ChatBoxViewModel { MessageChat = messageChat, CurrentUserNickName = user.NickName, CurrentMessageChatID = messageChat.ID };

            return PartialView("_ChatBox", viewModel);
        }

        public ActionResult GetPartial(int chatId)
        {
            
            var aspNetUserId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == aspNetUserId).Select(u => u.UserAccount).SingleOrDefault();
            var messageChat = db.MessageChatUsers
                         .Where(mcu => mcu.MessageChatId == chatId)
                         .Include(mcu => mcu.Chat)
                         .Select(mcu => mcu.Chat)
                         .Include(c => c.ChatHistory.Select(ch=>ch.User))
                         .FirstOrDefault();
            
            var viewModel = new ChatBoxViewModel {  MessageChat= messageChat, CurrentUserNickName=user.NickName, CurrentMessageChatID=messageChat.ID };


            return PartialView("_ChatBox", viewModel);
        }


        public ActionResult ChatWith(int currentUserId, int requestedUserID)
        {
            var followRelation1 = db.Follows
                                   .SingleOrDefault(f => f.FollowerId == currentUserId && f.UserId == requestedUserID);

            var followRelation2 = db.Follows
                             .SingleOrDefault(f => f.FollowerId == requestedUserID && f.UserId == currentUserId);

            if (followRelation1 == null || followRelation2 == null)
                return HttpNotFound();

            var currentGGuser = db.GamersGridUsers.SingleOrDefault(u => u.ID == currentUserId);
            var requestedGGuser = db.GamersGridUsers.SingleOrDefault(u => u.ID == requestedUserID);


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
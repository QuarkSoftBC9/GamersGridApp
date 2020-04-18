
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GamersGridApp.Perstistence;
using GamersGridApp.Core;
using GamersGridApp.Core.ViewModels;
using GamersGridApp.Core.Models;

namespace GamersGridApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        // GET: Message

        private readonly IUnitOfWork UnitOfWork;

        //var currentUser = db.Users.Where(u => u.Id == CurrentUserID).SingleOrDefault();
        public MessageController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;

        }
        public ActionResult MessageBoard()
        {
            var CurrentUserID = User.Identity.GetUserId();
            var currentUser = UnitOfWork.GGUsers.GetLoggedUser(CurrentUserID);
            //db.Users.Where(u => u.Id == CurrentUserID).Select(u => u.UserAccount).SingleOrDefault();
            var messageChats = UnitOfWork.MessageChats.GetMessageChats(currentUser.ID);
                //db.MessageChats
                //.Where(mc => mc.MessageChatUsers.Select(mcu=>mcu.UserId).Any(u=>u.Equals(currentUser.ID)))
                //.Include(c => c.ChatHistory.Select(ch=>ch.User))
                //.Include(mc=>mc.MessageChatUsers.Select(mcu=>mcu.User))
                //.ToList();

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
            var user = UnitOfWork.GGUsers.GetLoggedUser(userId);
            //db.Users.Where(u => u.Id == userId).Select(u => u.UserAccount).SingleOrDefault();
            var RequestedUser = UnitOfWork.GGUsers.GetUser(ID);
            //db.Users.Select(u => u.UserAccount).FirstOrDefault(u => u.ID == ID);

            var messageChat = UnitOfWork.MessageChats.GetMessageChatOfTwoUsers(user.ID, RequestedUser.ID);
            //    db.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == user.ID))
            //.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == RequestedUser.ID))
            //.Where(m => m.MessageChatUsers.Count == 2)
            //.Include(c=>c.ChatHistory.Select(ch=>ch.User))
            //.Include(c=>c.MessageChatUsers).FirstOrDefault();

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

                UnitOfWork.MessageChats.AddMessageChatToDB(newMessageChat);
                //db.MessageChats.Add(newMessageChat);
                UnitOfWork.Complete();

             messageChat = UnitOfWork.MessageChats.GetMessageChatOfTwoUsers(user.ID, RequestedUser.ID);


                    //db.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == user.ID))
                    //        .Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == RequestedUser.ID))
                    //        .Where(m => m.MessageChatUsers.Count == 2)
                    //        .Include(c => c.ChatHistory.Select(ch => ch.User))
                    //        .Include(c => c.MessageChatUsers).FirstOrDefault();

            }
            var viewModel = new ChatBoxViewModel { MessageChat = messageChat, CurrentUserNickName = user.NickName, CurrentMessageChatID = messageChat.ID };

            return PartialView("_ChatBox", viewModel);
        }

        public ActionResult GetPartial(int chatId)
        {
            
            var aspNetUserId = User.Identity.GetUserId();
            var user = UnitOfWork.GGUsers.GetLoggedUser(aspNetUserId);
            //db.Users.Where(u => u.Id == aspNetUserId).Select(u => u.UserAccount).SingleOrDefault();
            var messageChat = UnitOfWork.MessageChats.GetMessageChat(chatId);
                //db.MessageChatUsers
                //         .Where(mcu => mcu.MessageChatId == chatId)
                //         .Include(mcu => mcu.Chat)
                //         .Select(mcu => mcu.Chat)
                //         .Include(c => c.ChatHistory.Select(ch=>ch.User))
                //         .FirstOrDefault();
            
            var viewModel = new ChatBoxViewModel {  MessageChat= messageChat, CurrentUserNickName=user.NickName, CurrentMessageChatID=messageChat.ID };


            return PartialView("_ChatBox", viewModel);
        }


        public ActionResult ChatWith(int currentUserId, int requestedUserID)
        {
            var followRelation1 = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(currentUserId, requestedUserID);
            var followRelation2 = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(requestedUserID, currentUserId);

            if (followRelation1 == null || followRelation2 == null)
                return HttpNotFound();

            var currentGGuser = UnitOfWork.GGUsers.GetUser(currentUserId);
            var requestedGGuser = UnitOfWork.GGUsers.GetUser(requestedUserID);


            var messageChatsUsersBoth = UnitOfWork.MessageChatUsers.GetMessageChatRelationsForTwoUsers(currentUserId, requestedUserID);
            //db.MessageChatUsers.Where(mcu => mcu.UserId == currentGGuser.ID || mcu.UserId == requestedGGuser.ID).Include(mcu => mcu.Chat).ToList();


            var messageChats = UnitOfWork.MessageChats.GetMessageChatsIncludedChatHistory(currentGGuser.ID);
            //db.MessageChatUsers.Where(mcu => mcu.UserId == currentGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();
            var messageChatsOfRequestedUser = UnitOfWork.MessageChats.GetMessageChatsIncludedChatHistory(requestedGGuser.ID);
                //db.MessageChatUsers.Where(mcu => mcu.UserId == requestedGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();


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


                UnitOfWork.MessageChatUsers.AddMessageChatUserToDB(messageChatUser1);
                UnitOfWork.MessageChatUsers.AddMessageChatUserToDB(messageChatUser2);
                //db.MessageChatUsers.Add(messageChatUser1);
                //db.MessageChatUsers.Add(messageChatUser2);
                UnitOfWork.MessageChats.AddMessageChatToDB(newMessageChat);
                //db.MessageChats.Add(newMessageChat);
                UnitOfWork.Complete();

                messageChats = UnitOfWork.MessageChats.GetMessageChatsIncludedChatHistory(currentGGuser.ID);
                //db.MessageChatUsers.Where(mcu => mcu.UserId == currentGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();
                messageChatsOfRequestedUser = UnitOfWork.MessageChats.GetMessageChatsIncludedChatHistory(currentGGuser.ID);
                //db.MessageChatUsers.Where(mcu => mcu.UserId == requestedGGuser.ID).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();

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
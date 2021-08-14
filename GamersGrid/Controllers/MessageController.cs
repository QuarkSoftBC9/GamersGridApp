using GamersGrid.BLL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Models.Messageboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {

        private readonly SignInManager<GGuser> _signInManager;
        private readonly UserManager<GGuser> _userManager;
        private readonly ILogger<MessageController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public MessageController(ILogger<MessageController> logger,
            SignInManager<GGuser> signInManager,
            UserManager<GGuser> userManager,
            IUnitOfWork uow)
        {
            _logger = logger;
            unitOfWork = uow;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public async Task<IActionResult> MessageBoard()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var messageChats = await unitOfWork.db.UserChatGroups
                .Include(ucg => ucg.Group)
                .Include(ucg => ucg.Group.UserChatGroups)
                .ThenInclude(ucg=>ucg.User)
                .Include(ucg => ucg.Group.Messages)
                .ThenInclude(m=>m.User)
                .Where(ucg => ucg.UserId == currentUser.Id)
                .Select(ucg => ucg.Group)
                .ToListAsync();


            if (messageChats.Count != 0)
            {
                var currentChat = messageChats.FirstOrDefault();
                var viewmodel = new MessageboardVM(messageChats, currentChat.Id, currentUser.NickName);
                return View(viewmodel);
            }
            else
            {
                var viewmodel = new MessageboardVM( currentUser.NickName);
                return View(viewmodel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindMessageChats(int ID)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var RequestedUser =  unitOfWork.GGUsers.GetUser(ID);

            var chatGroup = await unitOfWork.db.ChatGroups
                .Where(cg =>
                cg.UserChatGroups.Any(ucg => ucg.UserId == currentUser.Id) &&
                cg.UserChatGroups.Any(ucg => ucg.UserId == RequestedUser.Id))
                .Include(cg => cg.Messages)
                .FirstOrDefaultAsync();


            if (chatGroup == null)
            {
                 chatGroup = new ChatGroup()
                {
                    Name = RequestedUser.NickName,
                    UserChatGroups = new List<UserChatGroup>(),
                    Messages = new List<Message>()
                };

                var chatGroupRelation1 = new UserChatGroup()
                {
                    User = currentUser,
                    Group = chatGroup
                };

                var chatGroupRelation2 = new UserChatGroup()
                {
                    User = RequestedUser,
                    Group = chatGroup
                };

                chatGroup.UserChatGroups.Add(chatGroupRelation1);
                chatGroup.UserChatGroups.Add(chatGroupRelation2);

                unitOfWork.db.ChatGroups.Add(chatGroup);
                await unitOfWork.Save();


                chatGroup = await unitOfWork.db.ChatGroups
                .Where(cg =>
                cg.UserChatGroups.Any(ucg => ucg.UserId == currentUser.Id) &&
                cg.UserChatGroups.Any(ucg => ucg.UserId == RequestedUser.Id))
                .Include(cg => cg.Messages)
                .FirstOrDefaultAsync();


            }
            var viewModel = new ChatGroupVM { Group = chatGroup, CurrentUserNickName = currentUser.NickName, CurrentMessageChatID = chatGroup.Id };

            return PartialView("_ChatBox", viewModel);
        }

        public async Task<IActionResult> GetPartial(int chatId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            //db.Users.Where(u => u.Id == aspNetUserId).Select(u => u.UserAccount).SingleOrDefault();
            var chatGroup = await unitOfWork.db.ChatGroups.Where(cg => cg.Id == chatId)
                .Include(cg=>cg.Messages)
                .FirstOrDefaultAsync();


            var viewModel = new ChatGroupVM { Group = chatGroup, CurrentUserNickName = currentUser.NickName, CurrentMessageChatID = chatGroup.Id };


            return PartialView("_ChatBox", viewModel);
        }


        public async Task<IActionResult> ChatWith(int currentUserId, int requestedUserID)
        {
            var followRelation1 = unitOfWork.FollowRelations.GetFollowRelationOfTwoUsers(currentUserId, requestedUserID);
            var followRelation2 = unitOfWork.FollowRelations.GetFollowRelationOfTwoUsers(requestedUserID, currentUserId);

            if (followRelation1 == null || followRelation2 == null)
                return NotFound();

            var currentUser = unitOfWork.GGUsers.GetUser(currentUserId);
            var RequestedUser = unitOfWork.GGUsers.GetUser(requestedUserID);

            var chatGroup = await unitOfWork.db.ChatGroups
                .Where(cg =>
                cg.UserChatGroups.Any(ucg => ucg.UserId == currentUser.Id) &&
                cg.UserChatGroups.Any(ucg => ucg.UserId == RequestedUser.Id))
                .Include(cg => cg.Messages)
                .FirstOrDefaultAsync();


            if (chatGroup == null)
            {
                chatGroup = new ChatGroup()
                {
                    Name = RequestedUser.NickName,
                    UserChatGroups = new List<UserChatGroup>(),
                    Messages = new List<Message>()
                };

                var chatGroupRelation1 = new UserChatGroup()
                {
                    User = currentUser,
                    Group = chatGroup
                };

                var chatGroupRelation2 = new UserChatGroup()
                {
                    User = RequestedUser,
                    Group = chatGroup
                };

                chatGroup.UserChatGroups.Add(chatGroupRelation1);
                chatGroup.UserChatGroups.Add(chatGroupRelation2);

                unitOfWork.db.ChatGroups.Add(chatGroup);
                await unitOfWork.Save();


                chatGroup = await unitOfWork.db.ChatGroups
                .Where(cg =>
                cg.UserChatGroups.Any(ucg => ucg.UserId == currentUser.Id) &&
                cg.UserChatGroups.Any(ucg => ucg.UserId == RequestedUser.Id))
                .Include(cg => cg.Messages)
                .FirstOrDefaultAsync();


            }


            var chatGroupsOfCurrentUser = await unitOfWork.db.UserChatGroups
                .Where(ucg => ucg.UserId == currentUser.Id)
                .Include(ucg => ucg.Group)
                .ThenInclude(g => g.Messages)
                .Select(ucg => ucg.Group)
                .ToListAsync();

            var viewModel = new MessageboardVM(chatGroupsOfCurrentUser, chatGroup.Id, currentUser.NickName);


            return View("MessageBoard", viewModel);
        }

    }
}

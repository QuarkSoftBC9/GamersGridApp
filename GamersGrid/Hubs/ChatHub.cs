using GamersGrid.BLL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Hubs
{
    public class ChatHub : Hub
    {

        private readonly IUnitOfWork uow;
        private readonly ILogger<ChatHub> logger;
        private readonly UserManager<GGuser> userManager;
        public ChatHub(ILogger<ChatHub> _logger, IUnitOfWork _uow, UserManager<GGuser> _userManager)
        {
            uow = _uow;
            logger = _logger;
            userManager = _userManager;
        }

        public async Task Connect(string id)
        {
            await Clients.Caller.SendAsync("connect", "OK");
        }

        public override async Task OnConnectedAsync()
        {
            var user = await userManager.GetUserAsync(Context.User);
            var chatGroups = await uow.db.UserChatGroups
                .Where(ucg => ucg.UserId == user.Id).Include(ucg => ucg.Group)
                .Select(ucg => ucg.Group)
                .ToListAsync();

            foreach (var chatgroup in chatGroups)
                await Groups.AddToGroupAsync(Context.ConnectionId, chatgroup.Id.ToString());


            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = await userManager.GetUserAsync(Context.User);
            var chatGroups = await uow.db.UserChatGroups
                .Where(ucg => ucg.UserId == user.Id).Include(ucg => ucg.Group)
                .Select(ucg => ucg.Group)
                .ToListAsync();
            foreach (var chatgroup in chatGroups)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatgroup.Id.ToString());

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToGroup(string userNickName, string message, int chatBoxID)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, chatBoxID.ToString());

            var user = await uow.GGUsers.GetFirstOrDefault(u => u.NickName == userNickName);

            var chatGroup = await uow.db.ChatGroups
                .Include(cg=>cg.Messages)
                .FirstOrDefaultAsync(m => m.Id == chatBoxID);
            chatGroup.Messages.Add(new Message { Value = message, User = user, Time = DateTime.Now });
            await uow.Save();
            //Clients.All.getMessages(user.Email, message);
            await Clients.Group(chatGroup.Id.ToString()).SendAsync("getMessages", user.NickName, message, DateTime.Now.ToShortDateString());

        }
    }
}

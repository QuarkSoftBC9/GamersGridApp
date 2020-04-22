using GamersGridApp.Core.Models;
using GamersGridApp.Persistence;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp
{
    public class NotificationsHub : Hub
    {
        private static readonly ConcurrentDictionary<int, string> Users = new ConcurrentDictionary<int, string>();

        public void Connect(int userId)
        {

            Users.GetOrAdd(userId, Context.ConnectionId);

        }

        public void SendNotificationPersonal(User userToNotify, Notification notification)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
            string userConnectionString;
            if (Users.TryGetValue(userToNotify.ID, out userConnectionString))
                hubContext.Clients.Client(userConnectionString).updateNotificationsPersonal(notification);


        }

        public void SendNotification(List<User> usersToNotify, Notification notification)
        {
            List<string> connectionsStrings = new List<string>();
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();

            foreach (var user in usersToNotify)
            {
                string userConnectionString;
                if (Users.TryGetValue(user.ID, out userConnectionString))
                    connectionsStrings.Add(userConnectionString);
            }

            if (connectionsStrings.Count > 0)
                hubContext.Clients.Clients(connectionsStrings).updateNotifications(notification);

        }
    }
}
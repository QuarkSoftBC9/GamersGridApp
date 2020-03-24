using GamersGridApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class Notification
    {
        public int ID { get; private set; }
        public DateTime TimeStamp { get; set; }

        public NotificationType Type { get; set; }

        public User User { get; set; }


        protected Notification() { }

        private Notification(NotificationType type, User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            Type = type;
            User = user;
            TimeStamp = DateTime.Now;
        }

        //public ICollection<UserNotification> UserNotifications { get; set; }

        //public int UserId { get; set; }
        public static Notification UserFollow(User user)
        {
            return new Notification(NotificationType.Followed,user);
        }
        public static Notification UserUnfollow(User user)
        {
            return new Notification(NotificationType.unFollowed, user);
        }

    }
}
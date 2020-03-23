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

        public ICollection<UserNotification> UserNotifications { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }

        
    }
}
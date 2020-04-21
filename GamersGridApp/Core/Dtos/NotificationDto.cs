using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Enums;
namespace GamersGridApp.Core.Dtos
{
    public class NotificationDto
    {
        public string content { get; set; }

        public int id { get;  set; }

        public DateTime timeStamp { get; set; }

        public NotificationType type { get; set; }

    }
}
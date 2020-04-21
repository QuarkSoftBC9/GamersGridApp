using GamersGridApp.Enums;
using GamersGridApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Models
{
    public class Notification : INewsFeed
    {
        public int ID { get; private set; }
       
        public DateTime TimeStamp { get; set; }

        public NotificationType Type { get; set; }

        public string Content { get; set; }



        protected Notification() {
            TimeStamp = DateTime.Now;
        }

        private Notification(NotificationType type, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("user");

            Type = type;
            TimeStamp = DateTime.Now;
            Content = content;
        }




        public static Notification Follow(User followee, User follower)
        {
            string content = $"{follower.NickName} is now following {followee.NickName}.";
            return new Notification(NotificationType.Follow,content);
        }
        public static Notification Unfollow(User followee, User follower)
        {
            string content = $"{follower.NickName} is no longer following {followee.NickName}.";
            return new Notification(NotificationType.Unfollow, content);
        }

        public static Notification FollowPersonal(User follower)
        {
            string content = $"{follower.NickName} is now following you.";
            return new Notification(NotificationType.FollowPersonal, content);
        }
        public static Notification UnfollowPersonal(User follower)
        {
            string content = $"{follower.NickName} is no longer following you.";
            return new Notification(NotificationType.Unfollow, content);
        }
    }
}
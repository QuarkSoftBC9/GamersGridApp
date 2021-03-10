﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models.Identity
{
    public class GGuser : IdentityUser<int>
    {
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; private set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; private set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string NickName { get; private set; }


        [StringLength(255, MinimumLength = 1)]
        public string Description { get; private set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string Country { get; private set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string City { get; private set; }
        public string Avatar { get; set; } = "/Content/Images/UserAvatars/boyAvatar.jpg";


        public string FullName => FirstName + " " + LastName;

        //public ICollection<Follow> Followers { get; set; }
        //public ICollection<Follow> Followees { get; set; }

        ////User Games N-N Relation
        //public ICollection<UserGame> UserGames { get; set; }

        //public ICollection<Photo> Photos { get; set; }
        //public ICollection<Video> Videos { get; set; }

        //public ICollection<MessageChatUser> MessageChatUsers { get; set; }

        //public ICollection<UserNotification> UserNotifications { get; set; }

        public GGuser()
        {

        }
        public GGuser(string nickname, string city, string country, string avatar)
        {
            NickName = nickname ?? throw new ArgumentNullException("Nickname is null");
            City = city ?? throw new ArgumentNullException("City is null");
            Country = country ?? throw new ArgumentNullException("Country is null");

            if (Avatar == null)
                Avatar = "/Content/Images/UserAvatars/boyAvatar.jpg";
            else
                Avatar = avatar;
        }

        public GGuser(string nickname, string city, string country)
        {
            NickName = nickname ?? throw new ArgumentNullException("Nickname is null");
            City = city ?? throw new ArgumentNullException("City is null");
            Country = country ?? throw new ArgumentNullException("Country is null");
        }

        public void Update(string firstname, string lastname, string nickname, string description, string country, string city)
        {
            FirstName = firstname;
            LastName = lastname;
            NickName = nickname;
            Description = description;
            Country = country;
            City = city;
        }
        public void Update(string avatar)
        {
            Avatar = avatar;
        }
        //public void Notify(Notification notification)
        //{
        //    UserNotifications.Add(new UserNotification(this, notification));
        //}
    }
}
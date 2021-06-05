using Microsoft.AspNetCore.Identity;
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
        public string FirstName { get;  set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get;  set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string NickName { get;  set; }


        [StringLength(255, MinimumLength = 1)]
        public string Description { get;  set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string Country { get;  set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string City { get;  set; }
        public string Avatar { get; set; }


        public string FullName => FirstName + " " + LastName;

        public ICollection<FollowRelation> Followers { get; set; }
        public ICollection<FollowRelation> Followees { get; set; }

        public ICollection<GameAccount> GameAccounts { get; set; }

        ////User Games N-N Relation
        public virtual ICollection<UsersGamesRelation> GamesRelations { get; set; }

        public virtual ICollection<UserChatGroup> RelatedChatGroups { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
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
        public void UpdateAvatar(string avatar)
        {
            Avatar = avatar;
        }
        //public void Notify(Notification notification)
        //{
        //    UserNotifications.Add(new UserNotification(this, notification));
        //}


        
    }
}

using GamersGridApp.Models.GameAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class User
    {
        public int ID { get; set; }

        //[Required]
        //public ApplicationUser UserAccount { get; set; }

        //[Required]
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

        //Lol Account
        public LOLAccount AccountLOL { get; set; }

        public string FullName => FirstName + " " + LastName;

        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> FollowedBy { get; set; }

        //User Games N-N Relation
        public ICollection<UserGame> UserGames { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Video> Videos { get; set; }

        public ICollection<MessageChat> MessageChats { get; set; }

        //Refactored ctors
        protected User() { }

        public User(string nickname, string city, string country, string avatar)
        {
            NickName = nickname ?? throw new ArgumentNullException("Nickname is null");
            City = city ?? throw new ArgumentNullException("City is null");
            Country = country ?? throw new ArgumentNullException("Country is null");

            if (Avatar == null)
                Avatar = "/Content/Images/UserAvatars/boyAvatar.jpg";
            else
                Avatar = avatar;
        }

        public static List<User> GetUsers() //Users repo 
        {
            return new List<User>()
            {
                new User(){ID = 1, FirstName = "Stanislav", LastName = "Novikov", NickName = "LeagueWarrior", City = "Vladivostok", Country = "Russia", Avatar="/Content/Images/UserAvatars/boyAvatar.jpg"},
                new User(){ID = 2, FirstName = "John", LastName = "Lezhino", NickName = "JohnLez", City = "Angers", Country = "France", Avatar="/Content/Images/UserAvatars/boyAvatar.jpg"},
                new User(){ID = 3, FirstName = "Chris", LastName = "Antonopoulos", NickName = "ChrisA", City = "Athens", Country ="Greece", Avatar="/Content/Images/UserAvatars/boyAvatar.jpg"},
                new User(){ID = 4, FirstName = "Maria", LastName = "Ntourmetaki", NickName = "Leaguer", City = "Heraklion", Country = "Greece", Avatar="/Content/Images/UserAvatars/girlAvatar.png"},
                new User(){ID = 5, FirstName = "Avraam", LastName = "Liautsis", NickName = "Lincoln", City = "New York", Country = "USA", Avatar="/Content/Images/UserAvatars/boyAvatar.jpg"}
            };
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
    }
}

    
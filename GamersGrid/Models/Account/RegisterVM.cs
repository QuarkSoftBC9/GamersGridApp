using GamersGrid.DAL.Models.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Account
{
    public class RegisterVM
    {
        public RegisterVM()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            NickName = string.Empty;
            Password = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            Avatar = string.Empty;
            FavoriteGame = string.Empty;
            AvatarImage = null;
        }

        public RegisterVM(string firstName, string lastName, string email, string nickName, string password, string city, string country, string avatar, string favoriteGame, IFormFile avatarImage)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NickName = nickName;
            Password = password;
            City = city;
            Country = country;
            Avatar = avatar;
            FavoriteGame = favoriteGame;
            AvatarImage = avatarImage;
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }
        [Required]
        public string FavoriteGame { get; set; }

        public IFormFile AvatarImage { get; set; }

        //public bool Dota { get; set; }
        //public bool Lol { get; set; }
        //public bool Cs { get; set; }




        public GGuser ExportGGUser() =>
            new GGuser
            {
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                NickName = this.NickName,
                UserName = this.Email,
                City = this.City,
                Country = this.Country
            };
    }
}

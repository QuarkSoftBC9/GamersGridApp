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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string NickName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }
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
                UserName = this.NickName,
                NormalizedUserName = this.NickName,
                City = this.City,
                Country = this.Country
            };
    }
}

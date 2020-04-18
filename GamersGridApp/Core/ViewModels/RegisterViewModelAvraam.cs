using GamersGridApp.Core.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ViewModels
{
    public class RegisterViewModelAvraam
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        //public bool Dota { get; set; }
        //public bool Lol { get; set; }
        //public bool Cs { get; set; }

        public string NickName { get; set; }

        [Required]
        [StringLength(16,MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }
        public string FavoriteGame { get; set; }
    }
}
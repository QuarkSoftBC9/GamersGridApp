﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GamersGridApp.Core.Models;

namespace GamersGridApp.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string NickName { get; set; }

        [StringLength(255, MinimumLength = 1)]
        public string Description { get; set; }

        [StringLength(255)]
        public string ProfilePhoto { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string Country { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string City { get; set; }
        public string Avatar { get; set; }

        // [Required]
        //[StringLength(50, MinimumLength = 1)]
        //public string Street_Name { get; set; }

        //public int Street_Number { get; set; }

        public string FullName => FirstName + " " + LastName;

        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> FollowedBy { get; set; }

        //User Games N-N Relation
        public ICollection<UserGame> UserGames { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
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

        [Required]
        public ApplicationUser UserAccount { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]

        public string FullName => FirstName + " " + LastName;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string NickName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public ICollection<User> Followers { get; set; }
        public ICollection<User> Followees { get; set; }

        //User Games N-N Relation
        public ICollection<UserGame> UserGames { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
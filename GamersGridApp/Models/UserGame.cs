using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class UserGame
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int GameID { get; set; }

        public User User { get; set; }
        public Game Game { get; set; }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Models
{
    public class Team
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }        
        public int AdminID { get; set; }
        public User Admin { get; set; }


    }
}
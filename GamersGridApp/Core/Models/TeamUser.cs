using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Models
{
    public class TeamUser
    {
        public int TeamID { get; set; }

        public Team Team { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public string Role { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string AccountIdentifier { get; set; }
        public AccountRegions AccountRegions { get; set; }
    }
}
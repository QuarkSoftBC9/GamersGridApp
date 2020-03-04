using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Models;

namespace GamersGridApp.ViewModels
{
    public class SearchViewModel
    {
        public List<User> Users { get; set; }
        public List<Game> Games { get; set; }
        public bool HasUsers { get; set; }
        public bool HasGames { get; set; }

        public SearchViewModel()
        {
            Users = new List<User>() { };
            Games = new List<Game>() { };
        }
    }
}
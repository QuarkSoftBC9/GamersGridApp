using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using GamersGridApp.Models;

namespace GamersGridApp.ViewModels
{
    public class SearchViewModel
    {
        public Collection<User> Users { get; set; }
        public Collection<Game> Games { get; set; }
        public bool HasUsers { get; set; }
        public bool HasGames { get; set; }

        public SearchViewModel()
        {
            Users = new Collection<User>() { };
            Games = new Collection<Game>() { };
        }
    }
}
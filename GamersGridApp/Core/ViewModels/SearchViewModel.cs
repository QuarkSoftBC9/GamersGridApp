using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using GamersGridApp.Core.Models;


namespace GamersGridApp.Core.ViewModels
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
        public SearchViewModel(List<User> users , List<Game> games , bool hasUsers, bool hasGames)
        {
            Users = users;
            HasUsers = hasUsers;
            Games = games;
            HasGames = hasGames;
        }
    }
}
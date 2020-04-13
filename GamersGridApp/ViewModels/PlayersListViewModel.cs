using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class PlayersListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IDictionary<int,string> UserFavoriteGame { get; set; }
        public int Test { get; set; }

    }
}
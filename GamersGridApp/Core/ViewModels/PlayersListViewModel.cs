using GamersGridApp.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ViewModels
{
    public class PlayersListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IDictionary<int,string> UserFavoriteGame { get; set; }
        public int Test { get; set; }

    }
}
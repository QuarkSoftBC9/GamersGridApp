using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class UserProfilePageViewModel
    {
        public User User { get; set; }
        public int FavoriteGameID { get; set; }
        public Game FavouriteGame { get; set; }
        public bool IsCurrent { get; set; }
        public int FollowsCount { get; set; }
        public int FollowingCount { get; set; }
        public int LoggedUserId { get; set; }
        public bool IsFollowing { get; set; }
        public IDictionary<string, GameAccountStats> GamesStats { get; set; }

    }
}
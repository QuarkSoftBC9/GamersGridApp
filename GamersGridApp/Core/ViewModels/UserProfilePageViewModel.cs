using GamersGridApp.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ViewModels
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

<<<<<<< Updated upstream
        public string GetOverWatchRank()
        {
            int rankInt;
            string rankString = GamesStats.Where(gs => gs.Key == "Overwatch").Select(mmr => mmr.Value.Rank).SingleOrDefault();
            if (!string.IsNullOrWhiteSpace(rankString))
            {
                rankInt = Int32.Parse(rankString);
                rankString = rankInt > 4000 ? "Competitive_Grandmaster_Icon.png" :
                rankInt > 3500 ? "Competitive_Master_Icon.png" :
                rankInt > 3000 ? "Competitive_Diamond_Icon.png" :
                rankInt > 2500 ? "Competitive_Platinum_Icon.png" :
                rankInt > 2000 ? "Competitive_Gold_Icon.png" :
                rankInt > 1500 ? "Competitive_Silver_Icon.png" :
                rankInt > 0 ? "Competitive_Bronze_Icon.png" : "no data";
            }
            return rankString;
        }
        public string GetDota2Rank()
        {
            int rankInt;
            string rankString = GamesStats.Where(gs => gs.Key == "Dota 2").Select(mmr => mmr.Value.Rank).SingleOrDefault();
            if (!string.IsNullOrWhiteSpace(rankString))
            {
                rankInt = Int32.Parse(rankString);
                rankString = rankInt > 5420 ? "Divine5.png" :
                    rankInt > 5420 ? "Divine4.png" :
                    rankInt > 5220 ? "Divine3.png" :
                    rankInt > 5020 ? "Divine2.png" :
                    rankInt > 4820 ? "Divine1.png" :
                    rankInt > 4620 ? "Ancient5.png" :
                    rankInt > 4466 ? "Ancient4.png" :
                    rankInt > 4312 ? "Ancient3.png" :
                    rankInt > 4158 ? "Ancient2.png" :
                    rankInt > 4004 ? "Ancient1.png" :
                    rankInt > 3850 ? "Legend5.png" :
                    rankInt > 3696 ? "Legend4.png" :
                    rankInt > 3542 ? "Legend3.png" :
                    rankInt > 3388 ? "Legend2.png" :
                    rankInt > 3234 ? "Legend1.png" :
                    rankInt > 3080 ? "Archon5.png" :
                    rankInt > 2926 ? "Archon4.png" :
                    rankInt > 2618 ? "Archon3.png" :
                    rankInt > 2464 ? "Archon2.png" :
                    rankInt > 2310 ? "Archon1.png" :
                    rankInt > 2156 ? "Crusader5.png" :
                    rankInt > 2002 ? "Crusader4.png" :
                    rankInt > 1848 ? "Crusader3.png" :
                    rankInt > 1694 ? "Crusader2.png" :
                    rankInt > 1540 ? "Crusader1.png" :
                    rankInt > 1386 ? "Guardian5.png" :
                    rankInt > 1232 ? "Guardian4.png" :
                    rankInt > 1078 ? "Guardian3.png" :
                    rankInt > 924 ? "Guardian2.png" :
                    rankInt > 770 ? "Guardian1.png" :
                    rankInt > 616 ? "Herald5.png" :
                    rankInt > 462 ? "Herald4.png" :
                    rankInt > 308 ? "Herald3.png" :
                    rankInt > 154 ? "Herald2.png" :
                     "Herald1.png";
            }
            return rankString;
        }
        public string GetLOLRank()
        {
            string rankString = GamesStats.Where(gs => gs.Key == "League Of Legends").Select(rank => rank.Value.Rank).SingleOrDefault();
            if (!string.IsNullOrWhiteSpace(rankString))
            {
                return rankString.Substring(0, rankString.IndexOf(" ")).ToLower() + ".png";

            }
            return rankString;
        }
=======
        
>>>>>>> Stashed changes
    }
    
}
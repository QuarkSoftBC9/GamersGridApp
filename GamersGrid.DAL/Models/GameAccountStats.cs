﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class GameAccountStats
    {
        [Key]
        [ForeignKey("GameAccount")]
        public int GameAccountId { get; set; }
        public GameAccount GameAccount { get; set; }

        public string KDA { get; set; }
        public string Rank { get; set; }
        public int Wins { get; set; }

        public int Losses { get; set; }
        public int HoursPlayed { get; set; }



        public void UpdateStats(string rank, int wins, int losses,string kda)
        {
            Rank = rank;
            Wins = wins;
            Losses = losses;
            KDA = kda;
        }

        public void UpdateStats(string rank, int wins, int losses)
        {
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }

        public string GetOverWatchRank()
        {
            int rankInt;
            //string rankString = GamesStats.Where(gs => gs.Key == "Overwatch").Select(mmr => mmr.Value.Rank).SingleOrDefault();
            if (Rank == null)
            {
                rankInt = 1;
            }
            else
            {
                rankInt = Int32.Parse(Rank);
            }
            var rankString = rankInt > 4000 ? "Competitive_Grandmaster_Icon.png" :
            rankInt > 3500 ? "Competitive_Master_Icon.png" :
            rankInt > 3000 ? "Competitive_Diamond_Icon.png" :
            rankInt > 2500 ? "Competitive_Platinum_Icon.png" :
            rankInt > 2000 ? "Competitive_Gold_Icon.png" :
            rankInt > 1500 ? "Competitive_Silver_Icon.png" :
            rankInt > 0 ? "Competitive_Bronze_Icon.png" : "no data";
            return rankString;
        }
        public string GetDota2Rank()
        {
            int rankInt;
            //string rankString = GamesStats.Where(gs => gs.Key == "Dota 2").Select(mmr => mmr.Value.Rank).SingleOrDefault();
            if (Rank == null)
            {
                rankInt = 1;
            }
            else
            {
                rankInt = Int32.Parse(Rank);
            }

            var rankString = rankInt > 5420 ? "Divine5.png" :
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
            return rankString;
        }
        public static string GetDota2Rank(string rank)
        {
            int rankInt;
            //string rankString = GamesStats.Where(gs => gs.Key == "Dota 2").Select(mmr => mmr.Value.Rank).SingleOrDefault();
            rankInt = Int32.Parse(rank);
            var rankString = rankInt > 5420 ? "Divine5.png" :
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
            return rankString;
        }
        public string GetLOLRank()
        {
            //string rankString = GamesStats.Where(gs => gs.Key == "League Of Legends").Select(rank => rank.Value.Rank).SingleOrDefault();
            return Rank.Substring(0, Rank.IndexOf(" ")).ToLower() + ".png";
        }
    }
}

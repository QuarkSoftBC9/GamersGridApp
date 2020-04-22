
using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Web;

namespace GamersGridApp.Core.Models
{
    public class GameAccountStats
    {
        [ForeignKey("GameAccount")]
        [Key]
        public int Id { get; set; }
        public GameAccount GameAccount { get; set; }
        public string KDA { get; set; }
        public string Rank { get; set; }
        public int Wins { get; set; }

        public int Losses { get; set; }
        public int HoursPlayed { get; set; }

        internal GameAccountStats()
        { }
        //Uncomment After relationShips are fixed
        public GameAccountStats(GameAccount account, string rank, int wins, int losses, string kda)
        {
            GameAccount = account;
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }
        public GameAccountStats(int id, string rank, int wins, int losses)
        {
            Id = id;
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }
        //Dota Update
        public void Update(DotaDto mainDto, DotaWinsLosesDto dotaWLDto, string kda)
        {
            KDA = kda;
            Wins = dotaWLDto.win;
            Losses = dotaWLDto.lose;
            Rank = Convert.ToString(mainDto.competitive_rank);
        }


        public void Update(OverWatchCompleteDto completeOwProfileDto)
        {
            string kda;

            if (completeOwProfileDto.competitiveStats.careerStats == null)
                kda = 0.ToString();
            else
            {
                kda = Convert.ToString(ExtraMethods.CalculateKda(
           completeOwProfileDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min,
           completeOwProfileDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min));
            }
            KDA = kda;
            Wins = completeOwProfileDto.gamesWon;
            Losses = 0;
            Rank = Convert.ToString(completeOwProfileDto.rating);
        }
        public void UpdateStats(string rank, int wins, int losses)
        {
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }
        public void UpdateKDA(List<LOLMatchesDto> listOfMatches, string accountId)
        {
            //some defensive programming should be added for values
            var kda = new List<double>();
            for (int i = 0, let = listOfMatches.Count; i < let; i++)
            {
                int playerId = listOfMatches[0].participantIdentities
                .Where(p => p.player.accountId == accountId)
                .Select(p => p.participantId).SingleOrDefault();

                kda.Add(GetKDA(listOfMatches[i], playerId));
            }
            var average = kda.Average();
            KDA = average.ToString("0.00");
        }
        public double GetKDA(LOLMatchesDto match, int playerID)
        {
            int kills = match.participants
                .Where(p => p.participantId == playerID)
                .Select(p => p.stats.kills)
                .SingleOrDefault();
            int deaths = match.participants
                .Where(p => p.participantId == playerID)
                .Select(p => p.stats.deaths)
                .SingleOrDefault();
            int assists = match.participants
                .Where(p => p.participantId == playerID)
                .Select(p => p.stats.assists)
                .SingleOrDefault();
            if (deaths == 0)
                return (double)kills + (double)assists;
            return ((double)kills + (double)assists) / (double)deaths;
        }
        public string GetOverWatchRank()
        {
            int rankInt;
            //string rankString = GamesStats.Where(gs => gs.Key == "Overwatch").Select(mmr => mmr.Value.Rank).SingleOrDefault();
            rankInt = Int32.Parse(Rank);
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
            rankInt = Int32.Parse(Rank);
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
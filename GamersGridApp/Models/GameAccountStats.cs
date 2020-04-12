using AutoMapper.QueryableExtensions;
using GamersGridApp.Dtos.ApiAcountsDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Web;

namespace GamersGridApp.Models
{
    public class GameAccountStats
    {
        [ForeignKey("GameAccount")]
        [Key]
        public int Id { get; set; }
        public GameAccount GameAccount { get;  set; }
        public string KDA { get;  set; }
        public string Rank { get;  set; }
        public int Wins { get;  set; }

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
        public GameAccountStats(GameAccount account, string rank, int wins, int losses)
        {
            GameAccount = account;
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }
        public void Update(string kda, int wins, int losses)
        {
            KDA = kda;
            Wins = wins;
            Losses = losses;
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
            for(int i =0, let = listOfMatches.Count; i < let; i++)
            {
                int playerId = listOfMatches[0].participantIdentities
                .Where(p => p.player.accountId == accountId)
                .Select(p => p.participantId).SingleOrDefault();

                kda.Add(GetKDA(listOfMatches[i], playerId));
            }
            var average = kda.Average();
            KDA = average.ToString("0.00");
        }
        public double GetKDA(LOLMatchesDto match , int playerID)
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
                return 0;  
            return ((double)kills + (double)(assists) / 3) / (double)deaths;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string KDA { get; set; }
        public string Rank { get;  set; }
        public int Wins { get;  set; }
        public int Losses { get; set; }
        public int HoursPlayed { get; set; }

        internal GameAccountStats()
        { }
        public GameAccountStats(GameAccount account, string rank, int wins, int losses)
        {
            GameAccount = account;
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }

        public void UpdateStats(string rank, int wins, int losses)
        {
            Rank = rank;
            Wins = wins;
            Losses = losses;
        }
    }
}
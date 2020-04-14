using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GamersGridApp.Enums;

namespace GamersGridApp.Models
{
    public class GameAccount
    {
        [ForeignKey("UserGame")]
        public int Id { get; set; }

        public string NickName { get;  set; }
        public string AccountIdentifier { get;  set; }
        public string AccountIdentifier2 { get; set; }
        public string AccountRegions { get; private  set; }
        public UserGame UserGame { get; set; }
        public GameAccountStats GameAccountStats { get; set; }

        //most properties could be set to private
        internal GameAccount()
        {  }
        //constructor for Dota2 and Overwatch
        public GameAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }
        //update lol stats
        public void UpdateStats(string tier, int wins, int loses)
        {
            if (GameAccountStats == null)
                GameAccountStats = new GameAccountStats(this.Id, tier, wins, loses);
            else
                GameAccountStats.UpdateStats(tier, wins, loses);
        }
        //constructor for Leage of Legends
        public GameAccount(string nickname, string identifier, string identifier2, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }
        //Update stats for Dota2 and Overwatch
        public void UpdateAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }
        //Update stats for Leage of Legends
        public void UpdateAccount(string nickname, string identifier, string identifier2, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }

    }
}
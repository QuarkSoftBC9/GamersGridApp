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

        internal GameAccount()
        {  }
        public GameAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }
        public GameAccount(UserGame userGame, string nickname, string identifier, string identifier2, string region)
        {
            UserGame = userGame;
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }
        public void UpdateAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }
        
        public void UpdateLOLAccount(string nickname, string identifier, string identifier2, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }

    }
}
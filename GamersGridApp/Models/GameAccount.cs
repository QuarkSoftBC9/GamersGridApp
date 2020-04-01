using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Enums;

namespace GamersGridApp.Models
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string NickName { get; private set; }
        public string AccountIdentifier { get; private set; }
        public AccountRegions AccountRegions { get; private  set; }
        public GameAccountStats GameAccountStats { get; set; }

        internal GameAccount()
        {  }
        public GameAccount(string nickname, string identifier, AccountRegions region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }
        public void UpdateLOLAccount(string nickname, string identifier, AccountRegions region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }

    }
}
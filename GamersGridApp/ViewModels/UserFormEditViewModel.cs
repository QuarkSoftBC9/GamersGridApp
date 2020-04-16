using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class UserFormEditViewModel
    {
       
        public int ID { get; set; }

        public string Avatar { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string SteamId { get; set; }
        public string BattleTag { get; set; }
        public string LolUsername { get; set; }
        public List<string> BattleNetRegions { get; set; }
        public List<string> RiotGamesRegions { get; set; }
        

        public UserFormEditViewModel(User user,UserGame dotaRelation,UserGame lolRelation,UserGame overwatchRelation)
        {
            if (user.ID == 0)
                throw new ArgumentNullException("User id is 0");
            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            NickName = user.NickName;
            Description = user.Description;
            Country = user.Country;
            City = user.City;
            Avatar = user.Avatar;

            SteamId = dotaRelation == null ? "" : dotaRelation.GameAccount.AccountIdentifier;
            BattleTag = lolRelation == null ? "" : overwatchRelation.GameAccount.AccountIdentifier;
            LolUsername = overwatchRelation == null ? "" : lolRelation.GameAccount.NickName; 

            BattleNetRegions = new List<string>() { "us", "eu", "asia" };
            RiotGamesRegions = new List<string>() { "BR1", "EUN1", "EUW1", "JP1","KR", "LA1", "LA2", "NA1",
                "OC1", "RU", "TR1"};

        }
        public UserFormEditViewModel() { }
    }
}
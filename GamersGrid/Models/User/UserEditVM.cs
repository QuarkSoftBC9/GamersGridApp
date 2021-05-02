
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.User
{
    public class UserEditVM
    {
        public int Id { get; set; }

        public string Avatar { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        public string Description { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string SteamId { get; set; }
        public string BattleTag { get; set; }
        public string LolUsername { get; set; }
        public List<string> BattleNetRegions { get; set; }
        public List<string> RiotGamesRegions { get; set; }

        public IFormFile AvatarImage { get; set; }

        public UserEditVM()
        {

        }

        public UserEditVM(GGuser user, List<GameAccount> gameAccounts)
        {
            if (user.Id == 0)
                throw new ArgumentNullException("User id is 0");

            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            NickName = user.NickName;
            Description = user.Description;
            Country = user.Country;
            City = user.City;
            Avatar = user.Avatar;

            const int lolId = 2;
            const int dotaId = 1;
            const int overwatchId = 3;

            var dotaAccount = gameAccounts.FirstOrDefault(gameAccount => gameAccount.GameId == 1);
            var lolAccount = gameAccounts.FirstOrDefault(gameAccount => gameAccount.GameId == 2);
            var overwatchAccount = gameAccounts.FirstOrDefault(gameAccount => gameAccount.GameId == 3);

            SteamId = dotaAccount == null  ? "" : dotaAccount.AccountIdentifier2;
            BattleTag = overwatchAccount == null  ? "" : overwatchAccount.AccountIdentifier;
            LolUsername = lolAccount == null  ? "" : lolAccount.NickName;


            //Initialize regions for dropdown lists 
            BattleNetRegions = new List<string>() { "us", "eu", "asia" };
            RiotGamesRegions = new List<string>() { "BR1", "EUN1", "EUW1", "JP1","KR", "LA1", "LA2", "NA1",
                "OC1", "RU", "TR1"};
        }
    }
}

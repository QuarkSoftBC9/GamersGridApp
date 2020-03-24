using GamersGridApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models.GameAccounts
{
    public class LOLAccount
    {
        [ForeignKey("User")]
        [Key]
        public int UserId { get; private set; }
        public User User { get; private set; }

        //Personal Data
        public string Name { get; set; }
        public string Puuid { get; set; }
        public string AccountId { get; set; }
        public string Id { get; set; }
        public LoLRegions  Region { get; private set; }

        public int SummonerLevel { get; set; }

        public void AddToUser(User user, int userId, LoLRegions region)
        {
            if (user == null)            
                throw new ArgumentNullException("User Account is null");
            
            UserId = UserId;
            Region = region;
            user.AccountLOL = this;
        }
    }
}
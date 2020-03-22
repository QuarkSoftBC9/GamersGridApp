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
        public int UserId { get; set; }
        public User User { get; set; }

        //Personal Data
        public string Name { get; set; }
        public string Puuid { get; set; }
        public string AccountId { get; set; }
        public string Id { get; set; }
        public LoLRegions  Region { get; set; }
        public int MyProperty { get; set; }

        public int SummonerLevel { get; set; }

    }
}
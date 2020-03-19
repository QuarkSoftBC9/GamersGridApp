using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models.GameAccounts
{
    public class AccountLOL
    {
        [ForeignKey("User")]
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Puuid { get; set; }
        public int summonerLevel { get; set; }
        public string AccountId { get; set; }
        public string Id { get; set; }
        public long RevisionDate { get; set; }

    }
}
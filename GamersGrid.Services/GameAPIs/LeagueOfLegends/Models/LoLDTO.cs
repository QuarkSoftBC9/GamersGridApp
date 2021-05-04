using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs.LeagueOfLegends.Models
{
    public class LoLDTO
    {
        public string name { get; set; }
        public string puuid { get; set; }
        public int summonerLevel { get; set; }
        public string accountId { get; set; }
        public string id { get; set; }
        public long revisionDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs.LeagueOfLegends.Models
{
    public class LoLStatsDTO
    {
        public string leagueId { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
        public string summonerName { get; set; }
        public int leaguePoints { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
    }
}

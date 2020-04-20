using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Dtos.ApiStatsDto
{
    public class LOLStatsDto
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
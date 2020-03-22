﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.ApiStatsDto
{
    public class LOLStatsDto
    {
        public string queueType { get; set; }
        public string summonerName { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public string rank { get; set; }
        public string tier { get; set; }
        public bool inactive { get; set; }
        public string leagueId { get; set; }
        public string summonerId { get; set; }
    }
}
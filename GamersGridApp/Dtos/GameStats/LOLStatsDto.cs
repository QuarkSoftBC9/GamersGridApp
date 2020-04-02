using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.GameStats
{
    public class LOLStatsDto
    {
        public string tier { get; set; }
        public string rank { get; set; }
        public int wins { get; set; }
    }
}
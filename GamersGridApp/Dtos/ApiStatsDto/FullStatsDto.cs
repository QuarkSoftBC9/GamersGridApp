using GamersGridApp.Dtos.ApiAcountsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.ApiStatsDto
{
    public class FullStatsDto
    {
        public LOLStatsDto Stats { get; set; }
        public LOLDto Account { get; set; }
        public LOLMatchesDto SingleMatch { get; set; }
    }
}
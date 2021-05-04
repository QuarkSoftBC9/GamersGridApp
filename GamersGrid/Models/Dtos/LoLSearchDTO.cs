using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Dtos
{
    public class LoLSearchDTO
    {
        public string accountName { get; set; }
        public string rank { get; set; }
        public string rankImagePath { get; set; }

        public string summonerLevel { get; set; }
        public string wins { get; set; }
        public string losses { get; set; }
    }
}

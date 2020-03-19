using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.ApiAcountsDtos
{
    public class LOLDto
    {
        public string name { get; set; }
        public string puuid { get; set; }
        public int summonerLevel { get; set; }
        public string accountId { get; set; }
        public string id { get; set; }
        public long revisionDate { get; set; }
    }
}
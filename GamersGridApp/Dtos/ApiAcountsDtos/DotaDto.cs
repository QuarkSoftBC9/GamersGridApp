using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.ApiAcountsDtos
{
    public class DotaDto
    {
        public string tracked_until { get; set; }
        public string solo_competitive_rank { get; set; }
        public string competitive_rank { get; set; }
        public int rank_tier { get; set; }
        public int leaderboard_rank { get; set; }
        public MmrEstimate mmr_estimate { get; set; }
        public ProfileData profile { get; set; }
    }

    public class MmrEstimate
    {
        public int estimate { get; set; }
    }

    public class ProfileData
    {
        public int account_id { get; set; }
        public string personaname { get; set; }
        public string name { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.ApiAcountsDtos
{

    public class DotaMatchDto
    {
        //public int? match_id { get; set; }
        public int? player_slot { get; set; }
        public bool? radiant_win { get; set; }
        public int? duration { get; set; }
        public int? game_mode { get; set; }
        public int? lobby_type { get; set; }
        public int? hero_id { get; set; }
        public int? start_time { get; set; }
        public int? version { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int? lane { get; set; }
        public int? lane_role { get; set; }
        public bool? is_roaming { get; set; }
        public int? cluster { get; set; }
        public int? leaver_status { get; set; }
        public int? party_size { get; set; }
    }
    public class DotaWinsLosesDto
    {
        public int win { get; set; }
        public int lose { get; set; }

    }

    public class DotaDto
    {
        public string tracked_until { get; set; }
        public string solo_competitive_rank { get; set; }
        public string competitive_rank { get; set; }
        public int? rank_tier { get; set; }
        public int? leaderboard_rank { get; set; }
        public MmrEstimate mmr_estimate { get; set; }
        public profile profile { get; set; }

    }


    public class MmrEstimate
    {
        public int? estimate { get; set; }
        public int? stdDev { get; set; }
        public int? n { get; set; }
    }

    public class profile
    {
        public int? account_id { get; set; }
        public string personaname { get; set; }
        public string name { get; set; }
        public bool? plus { get; set; }
        public int cheese { get; set; }
        public string steamid { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string profileurl { get; set; }
        public string last_login { get; set; }
        public string loccountrycode { get; set; }
        public bool? is_contributor { get; set; }

    }
}
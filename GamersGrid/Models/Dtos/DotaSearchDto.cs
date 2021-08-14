using GamersGrid.Services.GameAPIs.Dota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Dtos
{
    public class DotaSearchDto
    {
        public string PersonName { get; set; }
        public string CompetitiveRank { get; set; }
        public string CountryCode { get; set; }
        public string AvatarUrl { get; set; }
        public string KDA { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string RankIconPath { get; set; }



        public static DotaSearchDto From(DotaDTO dotaDto, DotaWinsLosesDTO dotaWLDto, string kda, string rankIcon)
            => new DotaSearchDto()
            {

                PersonName = dotaDto.profile.personaname,
                CompetitiveRank = dotaDto.competitive_rank,
                CountryCode = dotaDto.profile.loccountrycode,
                AvatarUrl = dotaDto.profile.avatarmedium,
                KDA = kda,
                Wins = dotaWLDto.win,
                Losses = dotaWLDto.lose,
                RankIconPath = $"/Static/Images/Games/DotaIcons/" + rankIcon
            };

    }
}

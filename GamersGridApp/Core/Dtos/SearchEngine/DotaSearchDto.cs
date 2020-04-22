
using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Core.Models;
using GamersGridApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Dto.SearchEngine
{
    public class DotaSearchDto
    {
        public string PersonName { get; set; }
        public string CompetitiveRank { get; set; }
        public string CountryCode { get; set; }
        public string AvatarUrl { get; set; }
        public double KDA { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string RankIconPath { get; set; }

        public DotaSearchDto(DotaDto mainDto, DotaWinsLosesDto wlDto, List<DotaMatchDto> matchesDto)
        {
            PersonName = mainDto.profile.personaname;
            CompetitiveRank = mainDto.competitive_rank;
            CountryCode = mainDto.profile.loccountrycode;
            AvatarUrl = mainDto.profile.avatarmedium;
            KDA = ExtraMethods.CalculateKda(matchesDto);
            Wins = wlDto.win;
            Losses = wlDto.lose;
            RankIconPath = GameAccountStats.GetDota2Rank(CompetitiveRank);
        }
    }
}
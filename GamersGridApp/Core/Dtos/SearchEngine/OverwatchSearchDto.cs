using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Dtos.SearchEngine
{
    public class OverwatchSearchDto
    {
        public double AverageKills { get; set; }
        public double AverageDeaths { get; set; }
        public string KDA { get; set; }
        public double Rank { get; set; }
        public string BattleTag { get; set; }
        public string Region { get; set; }
        public string RatingIcon { get; set; }
        public string PlayerIcon { get; set; }

        public OverwatchSearchDto(OverWatchCompleteDto completeDto,string battleTag, string region)
        {
            AverageKills = completeDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min;
            AverageDeaths = completeDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min;
            KDA = Convert.ToString(ExtraMethods.CalculateKda(
           completeDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min,
           completeDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min));
            Rank = completeDto.rating;
            BattleTag = battleTag;
            Region = region;
            RatingIcon = completeDto.ratingIcon;
            PlayerIcon = completeDto.icon;
        }
    }
}
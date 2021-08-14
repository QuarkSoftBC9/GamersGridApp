using GamersGrid.Services.GameAPIs.Overwatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Dtos
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


        public static OverwatchSearchDto From(OverWatchCompleteDTO owCompleteDto,string battleTag,string region)
        {
            var avgDeaths = owCompleteDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min;
            var avgEliminations = owCompleteDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min;

            var calculatedKda = Math.Round(avgEliminations / avgDeaths, 2);
            var kda = calculatedKda.ToString();



            var owSearchDto = new OverwatchSearchDto()
            {
                AverageKills = owCompleteDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min,
                AverageDeaths = owCompleteDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min,
                KDA = kda,
                Rank = owCompleteDto.rating,
                BattleTag = battleTag,
                Region = region,
                RatingIcon = owCompleteDto.ratingIcon,
                PlayerIcon = owCompleteDto.icon
            };

            return owSearchDto;
        }
    }
}

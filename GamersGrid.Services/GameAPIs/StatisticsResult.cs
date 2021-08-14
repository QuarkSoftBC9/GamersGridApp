using GamersGrid.Services.GameAPIs.Overwatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs
{
    public class StatisticsResult
    {

        public string NickName { get; set; }
        public string KDA { get; set; }
        public string Rank { get; set; }
        public int Wins { get; set; }

        public int Losses { get; set; }
        public int HoursPlayed { get; set; }









        public static StatisticsResult From(OverWatchCompleteDTO overWatchCompleteDTO)
        {
            string kda;

            if (overWatchCompleteDTO.competitiveStats.careerStats == null)
                kda = "0";
            else
            {
                var avgDeaths = overWatchCompleteDTO.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min;
                var avgEliminations = overWatchCompleteDTO.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min;

                var calculatedKda = Math.Round(avgEliminations / avgDeaths, 2);
                kda = calculatedKda.ToString();
            }

            var result = new StatisticsResult()
            {
                NickName = overWatchCompleteDTO.name,
                KDA = kda,
                Wins = overWatchCompleteDTO.gamesWon,
                Losses = 0,
                Rank = overWatchCompleteDTO.rating.ToString()
            };

            return result;
        }
    }
}

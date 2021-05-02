using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Seach
{
    public class SearchEngineVM
    {
        public List<string> BattleNetRegions { get; set; }
        public List<string> RiotGamesRegions { get; set; }

        public SearchEngineVM()
        {
            BattleNetRegions = new List<string>() { "us", "eu", "asia" };
            RiotGamesRegions = new List<string>() { "BR1", "EUN1", "EUW1", "JP1","KR", "LA1", "LA2", "NA1",
                "OC1", "RU", "TR1"};
        }
    }
}

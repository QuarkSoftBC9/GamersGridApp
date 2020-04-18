using GamersGridApp.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ViewModels
{
    public class LeaderBoardViewModel
    {
        public List<GameAccountStats> TopLolStats { get; set; }
        public List<GameAccountStats> TopDotaStats { get; set; }
        public List<GameAccountStats> TopOverwatchStats { get; set; }


        public LeaderBoardViewModel()
        {
            TopLolStats = new List<GameAccountStats>();
            TopDotaStats = new List<GameAccountStats>();
            TopOverwatchStats = new List<GameAccountStats>();
        }
    }

}
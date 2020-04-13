using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos.ApiAcountsDtos
{
    public class Awards
    {
        public int cards { get; set; }
        public int medals { get; set; }
        public int medalsBronze { get; set; }
        public int medalsSilver { get; set; }
        public int medalsGold { get; set; }
    }

    public class Games
    {
        public int played { get; set; }
        public int won { get; set; }
    }

    //public class CompetitiveStats
    //{
    //    public Awards awards { get; set; }
    //    public Games games { get; set; }
    //}

    //public class Awards2
    //{
    //    public int cards { get; set; }
    //    public int medals { get; set; }
    //    public int medalsBronze { get; set; }
    //    public int medalsSilver { get; set; }
    //    public int medalsGold { get; set; }
    //}

    //public class Games2
    //{
    //    public int played { get; set; }
    //    public int won { get; set; }
    //}

    public class QuickPlayStats
    {
        public Awards awards { get; set; }
        public Games games { get; set; }
    }

    public class Rating
    {
        public int level { get; set; }
        public string role { get; set; }
        public string roleIcon { get; set; }
        public string rankIcon { get; set; }
    }

    public class OverWatchProfileDto
    {
        //public CompetitiveStatsDto competitiveStats { get; set; }
        public int endorsement { get; set; }
        public string endorsementIcon { get; set; }
        public int gamesWon { get; set; }
        public string icon { get; set; }
        public int level { get; set; }
        public string levelIcon { get; set; }
        public string name { get; set; }
        public int prestige { get; set; }
        public string prestigeIcon { get; set; }
        public bool @private { get; set; }
        public QuickPlayStats quickPlayStats { get; set; }
        public int rating { get; set; }
        public string ratingIcon { get; set; }
        public List<Rating> ratings { get; set; }
    }

    public class OverWatchCompleteDto
    {
        public CompetitiveStats competitiveStats { get; set; }
        public int endorsement { get; set; }
        public string endorsementIcon { get; set; }
        public int gamesWon { get; set; }
        public string icon { get; set; }
        public int level { get; set; }
        public string levelIcon { get; set; }
        public string name { get; set; }
        public int prestige { get; set; }
        public string prestigeIcon { get; set; }
        public bool @private { get; set; }
        public QuickPlayStats quickPlayStats { get; set; }
        public int rating { get; set; }
        public string ratingIcon { get; set; }
        public object ratings { get; set; }
    }

    public class CompetitiveStats
    {
        public Awards awards { get; set; }
        public CareerStats careerStats { get; set; }

    }
    public class CareerStats
    {
        public AllHeroes allHeroes { get; set; }
    }
    public class AllHeroes
    {
        public Assists assists { get; set; }
        public Average average { get; set; }
        //public Best best { get; set; }
        //public Combat combat { get; set; }
        public object deaths { get; set; }
        public object heroSpecific { get; set; }
        //public Game game { get; set; }
        //public MatchAwards matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }
    public class Average
    {
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
    }

    public class Assists
    {
        public int defensiveAssists { get; set; }
        public int healingDone { get; set; }
        public int offensiveAssists { get; set; }
    }
}
LeagueUIController = (function () {
    DOM = {
        //league inputs selectors
        leagueName: "#league-name",
        leagueRegion: "#league-region",
        //league outputs selectors
        leagueStatsName: "#league-name-output",
        leagueStatsRank: "#league-rank",
        leagueStatsLevel: "#league-level",
        leagueStatsWins: "#league-wins",
        leagueStatsLosses: "#league-losses",
        leagueRankIcon: "#league-rank-icon"

    }
    let updateLeagueStats = function (stats) {
        $(DOM.leagueStatsName).html(stats.account.name);
        $(DOM.leagueStatsRank).html(stats.stats.tier + " " + stats.stats.rank);
        $(DOM.leagueStatsLevel).html(stats.account.summonerLevel);
        $(DOM.leagueStatsWins).html(stats.stats.wins);
        $(DOM.leagueStatsDeaths).html(stats.stats.losses);
        let rankLowerCase = stats.stats.rank.toLowerCase();
        let tierLowerCase = stats.stats.tier.toLowerCase();
        $(DOM.leagueRankIcon).attr("src", "/Content/Images/Games/LOLIcons/" + tierLowerCase + "_" + rankLowerCase + ".png");
    }
    return {
        updateLeagueStats: updateLeagueStats,

        selectAcc: function () {
            let name_lol = $(DOM.leagueName).val();
            let region_lol = $(DOM.leagueRegion).val();
            let account = { region: region_lol, name: name_lol }
            return account;
        },
        DOMStrings: DOM
    }
})();
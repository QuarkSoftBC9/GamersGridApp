let DotaUIController = (function () {
    let DOM = {
        dotaID: "#dota-id",
        dotaStatsName: "#dota-name-output",
        dotaStatsRank: "#dota-rank",
        dotaStatsKDA: "#dota-KDA",
        dotaStatsWins: "#dota-wins",
        dotaStatsLosses: "#dota-losses",
        dotaRankIcon: "#dota-rank-icon"
    }
    let updateStats = function (stats) {
        $(DOM.dotaStatsName).html(stats.personName);
        $(DOM.dotaStatsRank).html(stats.competitiveRank);
        $(DOM.dotaStatsKDA).html(stats.kda);
        $(DOM.dotaStatsWins).html(stats.wins);
        $(DOM.dotaStatsLosses).html(stats.losses);
        $(DOM.dotaRankIcon).attr("src", "/Content/Images/Games/DotaIcons/" + stats.rankIconPath);
    }
    return {
        SelectAcc: function () {
            return  $(DOM.dotaID).val();
        },
        updateDotaStats: updateStats
    }
})();
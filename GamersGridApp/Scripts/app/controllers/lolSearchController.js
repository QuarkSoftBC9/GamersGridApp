LeagueController = (function (LeagueSearchService, LeagueUIController) {

    let intialize = function () {
        console.log("League Search initialized");
        $('.league-search-btn').click(getLeagueAccount);
    }
    let getLeagueAccount = function () {
        let account = LeagueUIController.selectAcc();
        LeagueSearchService.sendAcc(account)
            .then(stats => {
                LeagueUIController.updateLeagueStats(stats);
            })
    }
    return {
        init: intialize,
    }
})(LeagueSearchService, LeagueUIController);


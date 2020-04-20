LeagueSearchService = (function () {

    let makeAPIcall = function (account) {
        return new Promise((resolve, reject) => {
            $.get("/api/LOLAccounts",
                { region: account.region, name: account.name },
                function (stats) {
                    console.log(stats);
                }).done(function (stats) {
                    resolve(stats);
                })
        });
    }
    return {
        sendAcc: function (account) {
            let promisedStats = makeAPIcall(account);
            return promisedStats;
        }
    }
})();
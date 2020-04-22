let DotaSearchService = (function () {

    let makeApiCall = function (accountID) {
        return new Promise((resolve, reject) => {
            let stringAccount = accountID.toString();
            console.log(stringAccount, typeof stringAccount);
            $.get("/api/DotaAccounts?accountid=" + stringAccount,
                function (stats) {
                    console.log(stats);
                }).done(function (stats) {
                    resolve(stats);
                })//fail validation should be added
        });
    }
    return {
        sendAcc: function (account) {
            let promisedStats = makeApiCall(account);
            return promisedStats;
        }
    }
})();
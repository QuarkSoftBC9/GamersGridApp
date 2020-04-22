let OverwatchApiService = function () {

    let GetStats = function (battleTag, region, overwatchSuccess, fail) {
        $.ajax({
            url: "api/OverwatchAccounts/",
            method: "get",
            data: { battleTag: battleTag, region: region }
        })
            .done(overwatchSuccess)
            .fail(fail);
    };

    return {
        getStats: GetStats
    };
}();
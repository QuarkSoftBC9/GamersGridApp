let DotaController = (function (DotaSearchService, DotaUIController) {
    let initialize = function () {
        console.log("Dota search initialized")
        $(".dota-search").click(getDotaAccount);
    }

    let getDotaAccount = function () {
        let account = DotaUIController.SelectAcc();
        DotaSearchService.sendAcc(account)
            .then(stats => {
                DotaUIController.updateDotaStats(stats); // stats validation should be added
            })
    }
    return {
        init: initialize
    }
})(DotaSearchService, DotaUIController)
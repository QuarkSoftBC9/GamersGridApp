let OverwatchSearchController = function (overwatchService) {

    let initial = function () {
        $(".overwatch-search").on("click", overwatchService.GetStats);
    };


    //let getOverwatchStats = function () {

    //};



    return {
        init: initial
    }
}(OverwatchService);
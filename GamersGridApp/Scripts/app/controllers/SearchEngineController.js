let SearchEngineController = function (overwatchApiService ) {

    let overwatchId;
    let overWatchRegion;


    let initial = function (element) {
        element.on("click", function () {
            overwatchId = $("#overwatchId").text();
            overWatchRegion = $("#battlenet-region").text();
            overwatchApiService.getStats(overwatchId, overwatchRegion, overwatchSuccess, fail);
        });
    };

    let overwatchSuccess = function (response) {
        $("#ow-Header").text(response.batteTag);
    };

    let fail = function (response) {
        console.log("failed");
    };


    return {
        eneableOverwatchSearch: initial
    };
    
}(OverwatcApiService);
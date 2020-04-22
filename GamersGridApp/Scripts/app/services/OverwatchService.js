let OverwatchService = function () {



    let getstats = function () {
        let model = getInputs();
        //let uri = "/api/OverwatchAccounts?battleTag=" + model.battleTag + "?region=" + model.region;
        $.get("/api/OverwatchAccounts", { battleTag: model.battleTag, region: model.region })
            .done(function (response) {
                $("#owHeader").text(response.battleTag);
                $("#overwatchRankIcon").attr("src", response.ratingIcon);
                $("#overwatch-rank").text(response.rank);
                $("#overwatch-Kills").text(response.averageKills);
                $("#overwatch-Deaths").text(response.averageDeaths);
                $("#overwatch-KDA").text(response.kda);
        }).fail(function (response) {
            console.log(response);
        });
    }


    let getInputs = function () {
        battletag = $("#overwatch-id").val();
        region = $("#battlenet-region").val();

        return { battleTag: battletag, region: region };
    };

    

    return {
        GetStats: getstats
    }
}();
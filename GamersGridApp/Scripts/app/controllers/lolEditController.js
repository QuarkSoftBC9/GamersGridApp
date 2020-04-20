let lolEditController = (function (UICntrl, APICntrl) {
    let initial = function () {
        $(".league-btn").click(GetLOLAcc);
    }

    let GetLOLAcc = function (event) {
        const account = UICntrl.selectAcc();
        console.log(account);
        APICntrl.addAccount(account);
    }
    return {
        init: initial
    }
})(LeagueUIController, APIController);
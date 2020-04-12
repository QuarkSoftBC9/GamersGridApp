let FollowsController = function (followsService) {
    let button
    let followerId;
    let followeeId;

    let initial = function (element) {
        $(element).on("click", toggleFollow);
    }

    let toggleFollow = function (e) {
        button = $(e.target);
        followerId = $("#loggedUserId").val();
        followeeId = $("#profileId").val();
        var dataModel = { followeeId: followeeId, followerId: followerId };
        if (button.text() === "Follow") {
            followsService.createFollow(dataModel, fail, followSuccess);
        } else {
            followsService.unFollow(dataModel, fail, unfollowSuccess);

        }
    };

    let followSuccess = function () {
        button.text("UnFollow");
        toastr.success("You are now following!");
    };

    let unfollowSuccess = function () {
        button.text("Follow");
        toastr.success("You are now no longer following");
    };

    let fail = function () {
        toastr.error("Something went wrong");
    };

    return {
        enable: initial
    };

}(FollowsService);
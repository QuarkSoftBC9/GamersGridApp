let FollowsController = function (followsService,messagesService) {
    let button
    let followerId;
    let followeeId;

    let initial = function (element) {
        $(element).on("click", toggleFollow);
    }

    let second = function (element) {
        $(element).on("click", redirectToChat);
    };

    

    let redirectToChat = function (e) {
        button = $(e.target);
        let url = button.data("redirect-url")
        followerId = $("#loggedUserId").val();
        followeeId = $("#profileId").val();
        var dataModel = { followeeId: followeeId, followerId: followerId };
        messagesService.redirectToChat(dataModel, url);
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
        let field = $("#followersCount");
        let fieldValue = parseInt(field.text());
        fieldValue = fieldValue + 1;
        field.text(fieldValue);

    };

    let unfollowSuccess = function () {
        button.text("Follow");
        toastr.success("You are now no longer following");
        let field = $("#followersCount");
        let fieldValue = field.text();
        fieldValue = fieldValue - 1;
        field.text(fieldValue);

    };

    let fail = function () {
        toastr.error("Something went wrong");
    };

    return {
        enableFollows: initial,
        enableMessaging: second
    };

}(FollowsService,MessagesService);
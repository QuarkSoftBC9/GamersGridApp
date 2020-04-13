let FollowsService = function () {
    let createFollow = function (dataModel, fail, followSuccess) {
        $.post("/api/follows/", dataModel)
            .done(followSuccess)
            .fail(fail);
    };

    let unFollow = function (dataModel, fail, unfollowSuccess) {
        $.ajax({
            url: "/api/follows/",
            method: "DELETE",
            data: dataModel
        })
            .done(unfollowSuccess)
            .fail(fail);
    };

    return {
        createFollow: createFollow,
        unFollow: unFollow
    };
}();

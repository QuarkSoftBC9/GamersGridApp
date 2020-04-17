let MessagesService = function () {
    let redirectToMessageChat = function (dataModel, redirectUrl) {
        $.get("/api/Follows", dataModel)
            .done(function () {
                window.location.href = redirectUrl;
            })
            .fail(function () {
                toastr.error("No mutual follow relation found");
            });
    };

    return {
        redirectToChat: redirectToMessageChat
    };

}();
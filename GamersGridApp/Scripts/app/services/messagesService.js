let MessagesService = function () {
    let redirectToMessageChat = function (dataModel, url) {
        $.ajax({
            url: "/api/messages",
            method: "GET",
            data: dataModel,
            contentType: "application/json"
        })
            .done(function () {
                window.location.href = url;
            })
            .fail(function () {
                toastr.error("No mutual follow relation found");
            });
    };

    return {
        redirectToChat: redirectToMessageChat
    };

}();
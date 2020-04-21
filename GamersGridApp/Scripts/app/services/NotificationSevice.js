

let NotificationService = function () {
    let Notifications;
    let GetNotifications = function (countElement, badgeElement) {
        $.getJSON("/api/notifications", function (notifications) {
            if (notifications.length == 0) {
                countElement
                    .text(0)
                    .removeClass("hide")
                    .addClass("animated bounceInDown");
                return;
            }
                

            Notifications = notifications;

            countElement
                .text(notifications.length)
                .removeClass("hide")
                .addClass("animated bounceInDown");

            badgeElement.popover({
                html: true,
                title: "Notifications",
                content: function () {
                    var compiled = _.template($("#notifications-template").html());
                    var html = compiled({ notifications: notifications })
                    return html;
                },
                placement: "bottom"
            })
        });
    };


    let UpdateToRead = function (countElement, badgeElement) {
        badgeElement.on("click", function () {
            if (Notifications !== undefined) {
                let notifications = Notifications;
                $.ajax({
                    url: "/api/notifications",
                    method: "PUT",
                    contentType: 'application/json',
                    data: JSON.stringify(notifications)
                }).done(function () {
                    Notifications = [];
                    countElement
                        .text(0)
                        .removeClass("animated bounceInDown");
                }).fail(function () {
                    console.log("something failed");
                });
            }
        });
    };


    return {
        getNotifications: GetNotifications,
        updateToRead: UpdateToRead
    };
}();
let NotificationsController = function (notificationService) {


    let initial = function (countElement, badgeElement) {
        notificationService.getNotifications(countElement, badgeElement);
        notificationService.updateToRead(countElement, badgeElement);
    };

    let second = function (userid, countElement, badgeElement) {
        var notificationsHub = $.connection.notificationsHub;
        notificationsHub.client.updateNotifications = function (notification) {

           
            console.log(notification.content);
            var count = countElement.text();
            console.log("count = " + count);
            count = Number(count) + 1;
            countElement.text(count);
            let ul = $("ul.notifications");
            let li = document.createElement("li");
            let text = notification.content;
            li.appendChild(text);
            ul.appendChild(li);


        };
        notificationsHub.client.updateNotificationsPersonal = function (notification) {
            console.log(notification.content);
            var count = countElement.text();
            console.log("count = " + count);
            count = Number(count) + 1;
            countElement.text(count);
            let ul = $("ul.notifications");
            let li = document.createElement("li");
            let text = notification.content;
            li.appendChild(text);
            ul.appendChild(li);



        };
           
        $.connection.hub.start().done(function () {
            notificationsHub.server.connect(userid);
            console.log("trexei o hub");
        });
       
    };


    return {
        startNotifications: initial,
        enableSignalR: second
    };

}(NotificationService);
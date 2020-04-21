let NotificationsController = function (notificationService) {



    let initial = function (countElement, badgeElement) {
        notificationService.getNotifications(countElement, badgeElement);
        notificationService.updateToRead(countElement,badgeElement);
    };



    return {
        startNotifications: initial
    };

}(NotificationService);
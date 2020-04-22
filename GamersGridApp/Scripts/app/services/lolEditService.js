let APIController = (function () {
    return {
        addAccount: function (account) {
            console.log(account);
            $.post("/api/LOLAccounts", { userName: account.name, region: account.region })
                .done(function (e) {
                    console.log(e);
                })
                .fail(function () {
                    toastr.error("Something failed");
                });
        },
    }
})();
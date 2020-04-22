let APIController = (function () {
    return {
        addAccount: function (account) {
            console.log(account);
            $.post("/api/LOLAccounts", { userName: account.name, region: account.region })
                .done(function (e) {
                    toastr.success("Account has been connected");
                    console.log(e);
                })
                .fail(function (responseText) {
                    toastr.error(responseText);
                });
        },
    }
})();
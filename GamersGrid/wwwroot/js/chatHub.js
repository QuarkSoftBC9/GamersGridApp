$(document).ready(function () { //This section will run whenever we call Chat.cshtml page

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();
    start();


    connection.onreconnecting(error => {
        console.log(error.toString());
    });

    connection.onreconnected(connectionId => {
        console.log(`Reconnected with connectionId :${connectionId.toString()}`);
    });

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };
    connection.onclose(start);


    connection.on("connect", function (data) {
        console.log(data);
    });


    var chatid = $("#btnSendMessage").attr("data-chat-id");
    var currentUserId = $("#usernickname").html();

    var searchUsers = new Bloodhound({ //*
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/messages?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $("#SearchUserToMessage").typeahead({
        hint: true,
        minLength: 2,
        highlight: true
    },
        {
            name: 'nickName',
            display: 'nickName',
            source: searchUsers
        })
        .on("typeahead:select", function (e, user) {

            $.ajax({
                url: '/Message/FindMessageChats',
                data: { ID: user.id },
                type: 'GET',
                success: function (data) {

                    $('#chatbox').replaceWith(data);
                    $(".chatLeft").removeClass("active_chat");
                    var chatId = $("#btnSendMessage").attr("data-chat-id");
                    $("#" + chatId).addClass("active_chat");


                }
            });



        });

    connection.on("getMessages", function (userName, message, time) {
        var div1class = "";
        var div2class = "";
        if (userName == currentUserId) {

            div1class = "outgoing_msg";
            div2class = "sent_msg";
        }
        else {
            div1class = "received_msg";
            div2class = "received_withd_msg";
        };
        $("#txtMessage").val('');
        $('#messageboard').append(' <div class="' +
            div1class +
            '"><div class="' + div2class + '"> <p>' + message + '</p> <span class="time_date">' + time + '</div> </div>');

        var height = $('#messageboard')[0].scrollHeight;
        $('#messageboard').scrollTop(height);
    });


    connection.on("connect", function (data) {
        console.log(data);
    });


    $(".msg_send_btn").on("click", function () {

        var message = $("#txtMessage").val();
        var chatBoxID = $("#btnSendMessage").attr("data-chat-id");
        let userNickName = $("#CurrentUserNickName").val();
        if (message.length > 0) {


            connection.invoke("SendMessageToGroup", userNickName.toString(), message.toString(), parseInt(chatBoxID));

        }
        $("#txtMessage").val("");
    });


    $(".chat_people").on("click", function (e) {
        var parent = $(e.target).closest("li");
        var messageChatId = parent.attr("id");
        $(".chatLeft").removeClass("active_chat");
        parent.addClass("active_chat");
        $.ajax({
            url: '/Message/GetPartial',
            data: { chatId: messageChatId },
            type: 'GET',
            method: "replace",
            success: function (data) {
                $('#chatbox').replaceWith(data);
            }
        });

        //$(".mesgs").load("/Message/GetPartial?chatId=" + messageChatId);
        //objHub.server.connect(messageChatId);

    });
});

$(document).ready(function () { //This section will run whenever we call Chat.cshtml page


    var objHub = $.connection.chatHub;
    var chatid = $("#btnSendMessage").attr("data-chat-id");


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


    objHub.client.getMessages = function (userName, message, time) {
        var div1class = "";
        var div2class = "";
        if (userName == "@Model.CurrentUserNickName") {

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


    }



    $(document).on("click", ".msg_send_btn", function () {

        var msg = $("#txtMessage").val();
        var chatboxid = $("#btnSendMessage").attr("data-chat-id");


        if (msg.length > 0) {


            // <<<<<-- ***** Return to Server [  SendMessageToGroup  ] *****
            objHub.server.sendMessageToGroup("@Model.CurrentUserNickName", msg, chatboxid);
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
        objHub.server.connect(messageChatId);

    });

    $.connection.hub.start().done(function () {
        objHub.server.connect(chatid);
    });
});
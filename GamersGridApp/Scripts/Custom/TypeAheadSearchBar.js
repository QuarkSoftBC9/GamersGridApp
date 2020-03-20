//Search
//var x = document.getElementById('Search').addEventListener('keypress', function (e) {
//    if (e.key === 'Enter') {
//        var search = ('#Search').value;
//        window.location.href = window.document + '/home/search?searchString=' + search;
//    }
//});

//$(function () {
//    $('#Search').keypress(function () {
//        var search = ('#Search').value;
//        if (code == 13) {
//            window.location.href = window.document + '/home/search?searchString=' + search;
//        }
//    });
//});

//New typeahead
$(document).ready(function () {
    var searchGames = new Bloodhound({ //*
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/games?query=%QUERY',
            wildcard: '%QUERY'
        }
    });
    var searchPlayers = new Bloodhound({ //*
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('nickName'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/users?query=%QUERY',
            wildcard: '%QUERY'
        }
    });
    
    $("#Search").typeahead({
        hint: true,
        minLength: 2,
        highlight: true
    },
        {
            name: 'title',
            display: 'title',
            source: searchGames //*
        },
        {
            name: 'nickName',
            display: 'nickName',
            source: searchPlayers //*
        })
        .on("typeahead:select", function (e, search) {

            if (search.title == null) {
                window.location.href = "/User/ProfilePage?userid=" + search.id;
            }
            else {
                window.location.href = "/Game/GameProfile?gameName=" + search.title;
            }
            
        });

});

//Old Function
//$(document).ready(function () {
//    var games = new Bloodhound({
//        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
//        queryTokenizer: Bloodhound.tokenizers.whitespace,
//        remote: {
//            url: '/api/games?query=%QUERY',
//            wildcard: '%QUERY'
//        }
//    });

//    $("#Search").typeahead({
//        hint: true,
//        minLength: 2,
//        highlight: true
//    },
//        {
//            name: 'games',
//            display: 'title',
//            source: games
//        })
//        .on("typeahead:select", function (e, game) {
//            window.location.href = "https://www.google.com/" /*"/Game/GameProfile?gameName=" + game.title*/;
//        });
//});
//console.log(5);

//Old Function
//$(document).ready(function () {
//    var games = new Bloodhound({
//        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
//        queryTokenizer: Bloodhound.tokenizers.whitespace,
//        remote: {
//            url: '/api/games?query=%QUERY',
//            wildcard: '%QUERY'
//        }
//    });

//    $("#Search").typeahead({
//        hint: true,
//        minLength: 2,
//        highlight: true
//    },
//        {
//            name: 'games',
//            display: 'title',
//            source: games
//        })
//        .on("typeahead:select", function (e, game) {

//            window.location.href = "/Game/GameProfile?gameName=" + game.title;
//        });
//});
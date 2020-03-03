$(document).ready(function () {
    var games = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/games?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $("#Search").typeahead({
        hint: true,
        minLength: 2,
        highlight: true
    },
        {
            name: 'games',
            display: 'title',
            source: games
        })
        .on("typeahead:select", function (e, game) {

            window.location.href = "/Game/GameProfile?gameName=" + game.title;
        });
});
//Mine
$(document).ready(function () {
    let dropdownNations = $('#Country');
    dropdownNations.empty();
    const url = 'https://restcountries.eu/rest/v2/all';

    dropdownNations.append('<option selected="true" disabled>Choose Nation</option>');
    dropdownNations.prop('selectedIndex', 0);

    // Populate DropDown
    $.getJSON(url, function (data) {
        $.each(data, function (key, entry) {
            dropdownNations.append($('<option></option>').attr('value', entry.name).text(entry.name));
        });
    });

});

function SearchSmth() {
    document.getElementsByClassName('searchBar').keydown(function (event) {
        console.log('log1')
        var search = ('.searchBar').value;
        if (event.which == 13) {
            window.location.href = window.document + '/home/search?searchString=' + search;
            location.href = window.document.codeform.code.value + '.html';
        }
    })
};

//Disabling Pressing Enter
$(document).keypress(
    function (event) {
        if (event.which == '13') {
            event.preventDefault();
        }
    });


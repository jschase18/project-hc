/*
* Performs search operation
*/
function searchClick() {
    $('#loading-message').removeClass('not-loading');
    $('#loading-message').addClass('loading');

    $('#table-search-results').find("tr:gt(0)").remove();

    var searchTerm = $('#text-search').val();

    if (!searchTerm) {
        $('#loading-message').removeClass('loading');
        $('#loading-message').addClass('not-loading');
        return;
    }

    $('#btn-search').prop('disabled', true);
    $('#btn-search').html('Searching...');

    sendSearchPeopleRequest(searchTerm, populateSearchResults);
    
    function populateSearchResults(data) {
        $('#loading-message').removeClass('loading');
        $('#loading-message').addClass('not-loading');

        $('#btn-search').prop('disabled', false);
        $('#btn-search').html('Search');

        if (data && data.length > 0) {
            var table = $('#table-search-results');
            var rowHtml = getSearchRowHtml();
            
            for (var i = 0; i < data.length; i++) {
                table.append(getSearchRowHtml(data[i].id, data[i].lastName, data[i].firstName, data[i].age));
            }
        }
    }

    function getSearchRowHtml(id, lastName, firstName, age) {
        return '<tr>' +
            '<td><button onclick="redirectToEditUrl(' + id + ')">Edit</button></td>' +
            '<td onclick="showDetailView(' + id + ')">' + firstName + '</td>' +
            '<td onclick="showDetailView(' + id + ')">' + lastName + '</td>' +
            '<td onclick="showDetailView(' + id + ')">' + age + '</td>' +
            '</tr>';
    }
}

/*
* Go to edit view
*/ 
function redirectToEditUrl(personId) {
    window.location.href = "/#/edit/" + personId;
}
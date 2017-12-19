/*
* Document Ready
*/
$(document).ready(function () {

    // load templates
    $("#search-content").load("app/views/search.html");
    $("#edit-content").load("app/views/edit.html");

    // set up routes
    setupRouting();

    function setupRouting() {
        Path.map("#/search").to(function () {
            $("#search-content").show();
            $("#edit-content").hide();
        });

        Path.map("#/edit/:personId").to(function () {
            $("#search-content").hide();
            $("#edit-content").show();
            showEditDetailView(this.params['personId']);
        });

        Path.root("#/search");

        Path.listen();
    }
});
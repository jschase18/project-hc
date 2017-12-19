/*
* Executes HTTP GET Request
*/
function sendHttpGetRequest(url, callback) {
    $.get(url, function (data) {
        callback(data);
    }, 'json');
}

/*
* Executes HTTP Post Request
*/
function sendHttpPostRequest(url, requestObj, callback) {
    $.post(url, requestObj, function (data) {
        callback(data);
    }, 'json');
}
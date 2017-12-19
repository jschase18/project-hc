/*
* Calls Get Contact Method Types API
*/
function sendGetContactMethodTypesRequest(callback) {
    return sendHttpGetRequest('catalog/contact-method-types', callback);
}

/*
* Calls Get States API
*/
function sendGetStatesRequest(callback) {
    return sendHttpGetRequest('catalog/states', callback);
}
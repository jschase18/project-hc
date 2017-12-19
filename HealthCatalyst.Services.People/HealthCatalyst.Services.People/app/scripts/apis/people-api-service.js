/*
* Calls Get Person Detail API
*/
function sendGetPersonDetailRequest(personId, callback) {
    return sendHttpGetRequest('people/' + personId, callback);
}

/*
* Calls Save Person API
*/
function sendSavePersonRequest(person, callback) {
    return sendHttpPostRequest('people', person, callback);
}

/*
* Calls Save Address API
*/
function sendSaveAddressRequest(personId, address, callback) {
    return sendHttpPostRequest('people/' + personId + '/address', address, callback);
}

/*
* Calls Save Contact Method API
*/
function sendSaveContactMethodRequest(personId, contactMethod, callback) {
    return sendHttpPostRequest('people/' + personId + '/contact-method', contactMethod, callback); 
}

/*
* Calls Save Interest API
*/
function sendSaveInterestRequest(personId, interest, callback) {
    return sendHttpPostRequest('people/' + personId + '/interest', interest, callback);
}

/*
* Calls Search People API
*/
function sendSearchPeopleRequest(searchTerm, callback) {
    return sendHttpGetRequest('people/search/' + searchTerm, callback);
}
/*
* Initialization Functions
*/

function showEditDetailView(personId) {

    clearFields();

    //populate person details
    sendGetPersonDetailRequest(personId, populateEditDetail);
}

function populateEditDetail(data) {

    clearFields();

    if (data) {

        // general
        populateGeneralInformation(data);
        $('#span-success-general').html('');

        // contact information
        if (data.contactMethods) {
            $.each(data.contactMethods, function (index, item) {
                //phone
                if (item.contactMethodTypeId == 1) {
                    populatePhoneNumber(item);
                }

                //email
                if (item.contactMethodTypeId == 2) {
                    populateEmailAddress(item);
                }
            });

            $('#span-success-contact-information').html('');
        }

        // address
        if (data.addresses) {
            populateAddress(data.addresses[0]);

            $('#span-success-address').html('');
        }

        // interests
        if (data.interests) {
            var table = $('#table-interests-edit');

            for (var i = 0; i < data.interests.length; i++) {
                table.append(getInterestRowHtml(data.interests[i]));
            }

            $('#error-message-interest').html('');
        }
    }

    //populate states
    sendGetStatesRequest(populateStates);
}

/*
* Populate Functions
*/

function clearFields() {
    $('#person-id-edit').val(0);
    $('#text-first-name').val('');
    $('#text-first-name').removeClass('text-required');
    $('#text-last-name').val('');
    $('#text-last-name').removeClass('text-required');
    $('#text-age').val('');
    $('#text-age').removeClass('text-required');
    $('#text-profile-picture-url').val('');
    $('#text-profile-picture-url').removeClass('text-required');
    $('#span-success-general').html('');
    $('#error-message-general').html('');

    $('#email-id-edit').val(0);
    $('#text-email').val('');
    $('#text-email').removeClass('text-required');
    $('#phone-id-edit').val(0);
    $('#text-phone').val('');
    $('#text-phone').removeClass('text-required');
    $('#span-success-contact-information').html('');
    $('#error-message-contact-information').html('');

    $('#address-id-edit').val(0);
    $('#text-address-one').val('');
    $('#text-address-one').removeClass('text-required');
    $('#text-address-two').val('');
    $('#text-address-two').removeClass('text-required');
    $('#text-city').val('');
    $('#text-city').removeClass('text-required');
    $('#text-postal-code').val('');
    $('#text-postal-code').removeClass('text-required');
    $('#selected-state-id').val(0);
    $('#span-success-address').html('');
    $('#error-message-address').html('');

    $('#table-interests-edit > tr').remove();
    $('#span-success-interest').html('');
    $('#error-message-interest').html('');
}

function populateAddress(address) {

    $('#address-id-edit').val(address.id);
    $('#text-address-one').val(address.address1);
    $('#text-address-two').val(address.address2);
    $('#text-city').val(address.city);
    $('#text-postal-code').val(address.postalCode);
    $('#selected-state-id').val(address.stateId);

    $('#span-success-address').html('Saved Successfully!');
    $('#btn-save-address').prop('disabled', false);
    $('#btn-save-address').html('Save');
}

function populateEmailAddress(email) {

    $('#email-id-edit').val(email.id);
    $('#text-email').val(email.value);

    $('#span-success-contact-information').html('Saved Successfully!');
    $('#btn-save-contact-information').prop('disabled', false);
    $('#btn-save-contact-information').html('Save');
}

function populateGeneralInformation(data) {

    $('#person-id-edit').val(data.id);
    $('#text-first-name').val(data.firstName);
    $('#text-last-name').val(data.lastName);
    $('#text-age').val(data.age);
    $('#text-profile-picture-url').val(data.profilePictureUrl);

    $('#span-success-general').html('Saved Successfully!');
    $('#btn-save-general').prop('disabled', false);
    $('#btn-save-general').html('Save');
}

function populateInterest(interest) {

    if (!$('#interest-id-' + interest.id).length) {
        var table = $('#table-interests-edit');
        table.append(getInterestRowHtml(interest));
    }

    $('#span-success-interest').html('Saved Successfully!');
    $('#btn-add-new-interest').prop('disabled', false);
    $('#btn-add-new-interest').html('Add Interest');
    $('#btn-save-interest-' + interest.id).prop('disabled', false);
    $('#btn-save-interest-' + interest.id).html('Save');
}

function populatePhoneNumber(phone) {
    $('#phone-id-edit').val(phone.id);
    $('#text-phone').val(phone.value);

    $('#span-success-contact-information').html('Saved Successfully!');
    $('#btn-save-contact-information').prop('disabled', false);
    $('#btn-save-contact-information').html('Save');
}

function populateStates(data) {
    var statesDropDown = $('#select-states');
    $.each(data, function (index, item) {
        statesDropDown.append($('<option></option>').val(item.id).html(item.name));
    });

    var stateId = parseInt($('#selected-state-id').val());
    $('#select-states').val(stateId).change();
}

/*
* Save Functions
*/

function addNewInterest() {

    $('#span-success-interest').html('');

    if (!doesPersonExistInSystem()) {
        isValid = false;
        $('#error-message-interest').html('***Must Save General Information***');
        return false;
    } else {
        $('#error-message-interest').html('');
    }

    $('#btn-add-new-interest').prop('disabled', true);
    $('#btn-add-new-interest').html('Adding New Interest...');

    var interest = {
        id: 0,
        description: '(Interest Description)'
    }

    sendSaveInterestRequest($('#person-id-edit').val(), interest, populateInterest);
}

function saveAddress() {

    $('#span-success-address').html('');

    if (!isAddressValid()) {
        return;
    }

    $('#btn-save-address').prop('disabled', true);
    $('#btn-save-address').html('Saving...');

    var address = {
        id: $('#address-id-edit').val(),
        address1: $('#text-address-one').val(),
        address2: $('#text-address-two').val(),
        city: $('#text-city').val(),
        stateId: $('#select-states').val(),
        postalCode: $('#text-postal-code').val()
    };

    sendSaveAddressRequest($('#person-id-edit').val(), address, populateAddress);
}

function saveContactInformation() {

    $('#span-success-contact-information').html('');

    if (!isContactInformationValid()) {
        return;
    }

    $('#btn-save-contact-information').prop('disabled', true);
    $('#btn-save-contact-information').html('Saving...');

    var phone = {
        id: $('#phone-id-edit').val(),
        contactMethodTypeId: 1,
        value: $('#text-phone').val()
    };

    sendSaveContactMethodRequest($('#person-id-edit').val(), phone, populatePhoneNumber);

    var email = {
        id: $('#email-id-edit').val(),
        contactMethodTypeId: 2,
        value: $('#text-email').val()
    };

    sendSaveContactMethodRequest($('#person-id-edit').val(), email, populateEmailAddress);
}

function saveGeneralInformation() {

    $('#span-success-general').html('');

    if (!isGeneralInformationValid()) {
        return;
    }

    $('#btn-save-general').prop('disabled', true);
    $('#btn-save-general').html('Saving...');

    var person = {
        id: $('#person-id-edit').val(),
        firstName: $('#text-first-name').val(),
        lastName: $('#text-last-name').val(),
        age: $('#text-age').val(),
        profilePictureUrl: $('#text-profile-picture-url').val()
    };

    sendSavePersonRequest(person, populateGeneralInformation);
}

function saveInterest(interestId) {

    $('#span-success-interest').html('');
    
    if (!isInterestValid(interestId)) {
        return;
    }

    $('#btn-save-interest-' + interestId).prop('disabled', true);
    $('#btn-save-interest-' + interestId).html('Saving...');

    var interest = {
        id: interestId,
        description: $('#interest-description-' + interestId).val()
    };

    sendSaveInterestRequest($('#person-id-edit').val(), interest, populateInterest);
}

/*
* Field Validation Functions
*/

function doesPersonExistInSystem() {
    var id = parseInt($('#person-id-edit').val());
    return id && id !== 0;
}

function isAddressValid() {
    var isValid = true;

    if (!doesPersonExistInSystem()) {
        isValid = false;
        $('#error-message-address').html('***Must Save General Information***');
        return false;
    }

    if (!$('#text-address-one').val()) {
        isValid = false;
        $('#text-address-one').addClass('text-required');
    } else {
        $('#text-address-one').removeClass('text-required');
    }

    if (!$('#text-city').val()) {
        isValid = false;
        $('#text-city').addClass('text-required');
    } else {
        $('#text-city').removeClass('text-required');
    }

    if (!$('#select-states').val()) {
        isValid = false;
        $('#select-states').addClass('text-required');
    } else {
        $('#select-states').removeClass('text-required');
    }

    if (!$('#text-postal-code').val()) {
        isValid = false;
        $('#text-postal-code').addClass('text-required');
    } else {
        $('#text-postal-code').removeClass('text-required');
    }

    if (!isValid) {
        $('#error-message-address').html('***Populate Required Fields***');
    } else {
        $('#error-message-address').html('');
    }

    return isValid;
}

function isContactInformationValid() {
    var isValid = true;

    if (!doesPersonExistInSystem()) {
        isValid = false;
        $('#error-message-contact-information').html('***Must Save General Information***');
        return false;
    }

    if (!$('#text-phone').val()) {
        isValid = false;
        $('#text-phone').addClass('text-required');
    } else {
        $('#text-phone').removeClass('text-required');
    }

    if (!$('#text-email').val()) {
        isValid = false;
        $('#text-email').addClass('text-required');
    } else {
        $('#text-email').removeClass('text-required');
    }

    if (!isValid) {
        $('#error-message-contact-information').html('***Populate Required Fields***');
        return;
    } else {
        $('#error-message-contact-information').html('');
    }

    return isValid;
}

function isGeneralInformationValid() {

    var isValid = true;

    if (!$('#text-first-name').val()) {
        isValid = false;
        $('#text-first-name').addClass('text-required');
    } else {
        $('#text-first-name').removeClass('text-required');
    }

    if (!$('#text-last-name').val()) {
        isValid = false;
        $('#text-last-name').addClass('text-required');
    } else {
        $('#text-last-name').removeClass('text-required');
    }

    if (!$('#text-age').val() || isNaN($('#text-age').val())) {
        isValid = false;
        $('#text-age').addClass('text-required');
    } else {
        $('#text-age').removeClass('text-required');
    }

    if (!$('#text-profile-picture-url').val()) {
        isValid = false;
        $('#text-profile-picture-url').addClass('text-required');
    } else {
        $('#text-profile-picture-url').removeClass('text-required');
    }

    if (!isValid) {
        $('#error-message-general').html('***Populate Required Fields***');
    } else {
        $('#error-message-general').html('');
    }

    return isValid;
}

function isInterestValid(interestId) {
    var isValid = true;

    if (!doesPersonExistInSystem()) {
        isValid = false;
        $('#error-message-contact-interest').html('***Must Save General Information***');
        return false;
    }

    if (!$('#interest-description-' + interestId).length || !$('#interest-description-' + interestId).val()) {
        isValid = false;
        if ($('#interest-description-' + interestId).length) {
            $('#interest-description-' + interestId).addClass('text-required');
        }
    } else {
        $('#interest-description-' + interestId).removeClass('text-required');
    }

    if (!isValid) {
        $('#error-message-interest').html('***Populate Required Fields***');
    } else {
        $('#error-message-interest').html('');
    }

    return isValid;
}

/*
* Utility Functions
*/

function getInterestRowHtml(interest) {
    return '<tr>' +
        '<td><button id="btn-save-interest-' + interest.id + '"onclick="saveInterest(' + interest.id + ')">Save</button></td>' +
        '<td><input type="hidden" id="interest-id-' + interest.id + '" value=' + interest.id + '></td>' +
        '<td><input type="text" id="interest-description-' + interest.id + '" value="' + interest.description + '"></input></td>' +
        '</tr>';
}
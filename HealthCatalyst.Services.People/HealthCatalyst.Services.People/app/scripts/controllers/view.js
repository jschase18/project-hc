/*
* Shows details of person
*/
function showDetailView(personId) {

    //populate person details
    sendGetPersonDetailRequest(personId, populateDetail);

    function populateDetail(data) {
        // general
        $('#img-profile').attr('src', data.profilePictureUrl);
        $('#person-id').val(data.id);
        $('#span-name').html(data.firstName + ' ' + data.lastName);
        $('#span-age').html(data.age);

        // contact information
        $('#phone-id').val(0);
        $('#span-phone').html('');

        $('#email-id').val(0);
        $('#span-email').html('');

        if (data.contactMethods && data.contactMethods.length > 0) {
            $.each(data.contactMethods, function (index, item) {
                //phone
                if (item.contactMethodTypeId == 1) {
                    $('#phone-id').val(item.id);
                    $('#span-phone').html(item.value);
                }

                //email
                if (item.contactMethodTypeId == 2) {
                    $('#email-id').val(item.id);
                    $('#span-email').html(item.value);
                }
            });
        }

        // address
        $('#address-id').val(0);
        $('#span-address-one').html('');
        $('#span-address-two').html('');
        $('#span-city').html('');
        $('#span-postal-code').html('');
        $('#state-id').val(0);
        $('#span-state').html('');

        if (data.addresses && data.addresses.length > 0) {
            var address = data.addresses[0];
            $('#address-id').val(address.id);
            $('#span-address-one').html(address.address1);
            if (address.address2) {
                $('#span-address-two').show();
                $('#span-address-two').html(address.address2);
            } else {
                $('#span-address-two').hide();
            }
            
            $('#span-city').html(address.city + ', ');
            $('#span-postal-code').html(address.postalCode);
            $('#state-id').val(address.stateId);
            sendGetStatesRequest(setState);
        }

        // interests
        $('#table-interests-view > tr').remove(); // clear table

        if (data.interests && data.interests.length > 0) {
            var table = $('#table-interests-view');

            for (var i = 0; i < data.interests.length; i++) {
                var interest = data.interests[i];
                table.append(getInterestRowHtml(interest.id, interest.description));
            }
        }

        function getInterestRowHtml(id, description) {
            return '<tr>' +
                '<td><input type="hidden" value=' + id + '></td>' +
                '<td>' + description + '</td>' +
                '</tr>';
        }

        function setState(data) {
            var stateId = parseInt($('#state-id').val());
            $.each(data, function (index, item) {
                if (item.id == stateId) {
                    $('#span-state').html(item.name);
                }
            });
        }
    }
}
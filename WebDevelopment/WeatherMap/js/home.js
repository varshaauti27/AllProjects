$(document).ready(function () {

});

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function getWeatherData() {
    var haveValidationErrors = checkAndDisplayValidationErrors($('#weather-form').find('input'));

    // If we have errors, bail out by returning false
    if (haveValidationErrors) {
        return false;
    }

    var keyCode = 'e8d259e4ccc929b7f1cbd8a8fdaea1f4';
    var zipCode = $('#txtZipCode').val();
    var units = $('#units-select').val();
    var URL = 'http://api.openweathermap.org/data/2.5/weather?zip=' + zipCode + '&units=' + units + '&appid=' + keyCode;
    alert("URL : " + URL);

    var tempUnit, windUnit;
    if (units == 'Imperial') {
        tempUnit = ' \xB0F';
        windUnit = ' miles/hour';
    }
    else if (units == 'Metric') {
        tempUnit = ' \xB0C';
        windUnit = ' meter/sec';
    }
    else {
        tempUnit = ' \xB0C';
        windUnit = ' meter/sec';
    }

    $.ajax({
        type: 'GET',
        url: URL,
        success: function (data) {
            //alert("Image Id: " + data.weather[0].icon);
            //alert("main: " + data.weather[0].main);
            //alert("description: " + data.weather[0].description);
            //alert("temp: " + data.main.temp);
            //alert("humidity: " + data.main.humidity);
            //alert("wind: " + data.wind.speed);

            var imageIcon = 'http://openweathermap.org/img/w/' + data.weather[0].icon + '.png';
            $('#currentConditionIcon').attr('src', imageIcon);
            $('#currentCity').text(data.name);
            $('#currentConditionMain').text(data.weather[0].main);
            $('#currentConditionDescription').text(data.weather[0].description);
            $('#currentTemperature').text(data.main.temp + tempUnit);
            $('#currentHumidity').text(data.main.humidity + '%');
            $('#currentWind').text(data.wind.speed + windUnit);

            $('#currentConditionDiv').show();
        },

        error: function (xhr, errorType, exception) {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));

            var responseText = (xhr.responseText);
            alert("Error type : " + errorType);
            alert("Exception : " + exception + "\nException Type :" + responseText.ExceptionType + "\nResponse Message: " + responseText.Message + "\nRespose StackTrace:" + responseText.StackTrace);
        }
    });
}

function checkAndDisplayValidationErrors(input) {
    // clear displayed error message if there are any
    $('#errorMessages').empty();
    // check for HTML5 validation errors and process/display appropriately
    // a place to hold error messages
    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function () {
        // Use the HTML5 validation API to find the validation errors
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    // put any error messages in the errorMessages div
    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}

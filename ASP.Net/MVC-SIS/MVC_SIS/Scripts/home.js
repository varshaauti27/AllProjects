$(document).ready(function(){

    //alert("Document ready !!!");
});


function validateStudent() {
    $('#errorMessages').empty();
    var haveValidationErrors = false;

    if ($('#txt-firstName').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter First Name"));
        haveValidationErrors = true;
        //return false;
    }

    if ($('#txt-lastName').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter Last Name"));
        haveValidationErrors = true;
        //return false;
    }

    if ($('#list-major').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Select Major"));
        haveValidationErrors = true;
        //return false;
    }

    if ($('#txt-GPA').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter GPA"));
        haveValidationErrors = true;
        //return false;
    }

    if ($('#list-courseId').val() == null) {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter course id"));
        haveValidationErrors = true;
        //return false;
    }

    if (haveValidationErrors)
        return false;

    return true;
}

function validateCourse() {
    $('#errorMessages').empty();
    var haveValidationErrors = false;

    if ($('#txt-courseName').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter Course Name"));
        haveValidationErrors = true;
        //return false;
    }

    if (haveValidationErrors)
        return false;

    return true;
}

function validateMajor() {
    $('#errorMessages').empty();
    var haveValidationErrors = false;

    if ($('#txt-majorName').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter Major"));
        haveValidationErrors = true;
        //return false;
    }

    if (haveValidationErrors)
        return false;

    return true;
}

function validateState() {
    $('#errorMessages').empty();
    var haveValidationErrors = false;

    if ($('#txt-stateAbbreviation').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter State Abbreviation"));
        haveValidationErrors = true;
        //return false;
    }

    if ($('#txt-stateName').val() == '') {
        $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text("Please Enter State Name"));
        haveValidationErrors = true;
        //return false;
    }

    if (haveValidationErrors)
        return false;

    return true;
}
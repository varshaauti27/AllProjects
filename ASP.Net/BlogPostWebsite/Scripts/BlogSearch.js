$(document).ready(function () {
    GetAllCategories();

    $("#search-select").on("change", function () {
        if ($('#search-select').val() == "Category") {
            $('#list-select').show();
            $('#search-term-text').hide();
        }
        else {
            $('#list-select').hide();
            $('#search-term-text').show();
        }
    });

    $('#search-button').click(function (event) {

        if ($('#search-select').val() == null) {
            $('#errorMessages').text("Please Enter Search Category");
            return false;
        }

        if ($('#search-term-text').val() == '' && $('#list-select').val() == null ) {
            $('#errorMessages').text("Please enter valid input");
            return false;
        }

        if ($('#search-select').val() == "Tag") {
            if ($('#search-term-text').val() == '') {
                $('#errorMessages').text("Please enter search term");
                return false;
            }
        }
    });
});


function GetAllCategories() {
    $.ajax({
        url: "/Blog/GetAllCategory",
        success: function (result) {
            $("#list-select").find("option").remove();
            for (var i = 0; i < result.length; i++) {
                $("#list-select").append("<option value='" + result[i].CategoryId + "'>" + result[i].Name + "</option>");
            }
        },
        error: function (error) {
            alert(error);
        }
    });

}
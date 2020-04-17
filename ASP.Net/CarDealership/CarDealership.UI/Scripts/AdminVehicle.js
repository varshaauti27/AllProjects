$(document).ready(function () {

    $("#list-make").on("change", function () {
        GetModelsOnMakeChange();
    });
    $("#list-type").on("change", function () {
        if ($("#list-type").val() == 1) {
            $("#mileage-text").attr("min", 0);
            $("#mileage-text").attr("max", 1000);
        }
        if ($("#list-type").val() == 2) {
            $("#mileage-text").attr("min", 1000);
            $("#mileage-text").attr("max", "");
        }
    });

    $("#btnDelete").on("click", function (e) {
        e.preventDefault();
        var result = confirm("Are you sure you want to delete the vehicle?");
        if (result == true) {
            window.location.href = $(this).attr("href");
        }
    });

});

function GetModelsOnMakeChange() {
    $.ajax({
        url: "/Admin/GetModelByMakeId/" + $("#list-make").val(),
        success: function (result) {
            $("#list-model").find("option").remove();
            for (var i = 0; i < result.length; i++) {
                $("#list-model").append("<option value='" + result[i].Id + "'>" + result[i].Name + "</option>");
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}
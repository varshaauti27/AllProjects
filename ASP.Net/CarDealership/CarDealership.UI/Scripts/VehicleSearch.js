var pageType = $("#pageName").val();

$(document).ready(function () {

    if (pageType === "Inventory") {
        //$('#control-button').text('Details');
        $('#control-button').append('<i class="fa fa-info fa-lg"></i>')
    }
    if (pageType === "Sales") {
        //$('#control-button').text('Purchase');
        $('#control-button').append('<i class="fa fa-shopping-cart fa-lg"></i>')
    }
    if (pageType === "Admin") {
        //$('#control-button').text('Edit');
        $('#control-button').append('<i class="fa fa-pencil fa-lg"></i>')
    }
});

function GetSearchData() {
 
        var isNewVehicle = $("#IsNewVehicle").val();

        var data = {};

        if (isNewVehicle == null || isNewVehicle == "") {
            data.IsNewVehicle = null;
        }
        else {
            data.IsNewVehicle = isNewVehicle;
        }

        data.SearchText = $("#SearchText-text").val();
        data.MinPrice = $("#MinPrice-ddl").val() == -1 ? null : $("#MinPrice-ddl").val();
        data.MaxPrice = $("#MaxPrice-ddl").val() == -1 ? null : $("#MaxPrice-ddl").val();
        data.MinYear = $("#MinYear-ddl").val() == -1 ? null : $("#MinYear-ddl").val();
        data.MaxYear = $("#MaxYear-ddl").val() == -1 ? null : $("#MaxYear-ddl").val();

        $("#NoResultFoundDiv").hide();

        $.ajax({
            type: "POST",
            url: "/Inventory/SearchVehicles",
            //data: { SearchRequest: data, pageNumber: pageNum, pageSize: pageSize },
            data: data,
            success: function (result) {
                if (result.length > 0) {
                    $("#NoResultFoundDiv").hide();
                }
                else {
                    $("#NoResultFoundDiv").show();
                }

                $("#SearchResultDiv").empty();

                for (var i = 0; i < result.length; i++) {
                    var div = $("#VehicleTemplate").clone();
                    $(div).show();

                    $(div).find("#vehicle-Heading").text(result[i].Year + " " + result[i].MakeName + " " + result[i].ModelName);
                    $(div).find("#vehicle-BodyStyle").text(result[i].BodyStyle);
                    $(div).find("#vehicle-ExteriorColor").text(result[i].ExteriorColor);
                    $(div).find("#vehicle-InteriorColor").text(result[i].InteriorColor);
                    $(div).find("#vehicle-TransmissionText").text(result[i].TransmissionText);

                    $(div).find("#vehicle-Mileage").text(result[i].Mileage);
                    $(div).find("#vehicle-Vin").text(result[i].Vin);
                    $(div).find("#vehicle-MSRP").text("$" + result[i].MSRP);
                    $(div).find("#vehicle-Image").attr("src", "/Images/" + result[i].ImageFile);
                    $(div).find("#vehicle-SalesPrice").text("$" + result[i].SalesPrice);

                    if (pageType === "Inventory") {
                        $(div).find("#control-button").attr("href", "/Inventory/Details/" + result[i].Vin);
                        //$('#control-button').text('Details');
                    }
                    else {
                        if (userAuthorized && (isAdmin || isSales)) {
                            if (pageType === "Sales") {
                                $(div).find("#control-button").attr("href", "/Sales/Purchase/" + result[i].Vin);
                                //$('#control-button').text('Purchase');
                            } else if (pageType === "Admin") {
                                $(div).find("#control-button").attr("href", "/Admin/EditVehicle/" + result[i].Vin);
                                //$('#control-button').text('Edit');
                            }
                        }
                    }
                    $("#SearchResultDiv").append(div);
                }
                $.notify("Search Successfully!!", "success");
            },
            error: function (error) {
                alert(JSON.stringify(error));
                $.notify("Error in searching", "error");
            }
        });
}
$(document).ready(function () {
    $('#from-datepicker').datepicker({
        format: 'mm-dd-yyyy'
    });
    $('#to-datepicker').datepicker({
        format: 'mm-dd-yyyy'
    });
});

function GetSalesReport() {
    $('#searchResultDiv').hide();
    $('#noResultDiv').hide();

    var userId = $("#list-users").val();
    var fromDate = $("#from-datepicker").val();
    var toDate = $("#to-datepicker").val();

    //alert("User Id" + userId);
    //alert("From Date" + fromDate);
    //alert("To Date" + toDate);

    $.ajax({
        type: "GET",
        url: "/Reports/GetSalesReport?userId=" + userId + "&fromDate=" + fromDate + "&toDate=" + toDate,
        success: function (result) {
            $("#contentRows").empty();
            for (var i = 0; i < result.SalesReport.length; i++) {
                var row = '<tr><td id="tdUser">' + result.SalesReport[i].UserName + '</td><td id="tdTotalSales">$' + result.SalesReport[i].TotalSales + '</td><td id="tdTotalVehicles">' + result.SalesReport[i].TotalVehicles + '</td></tr>';
                $("#contentRows").append(row);
            }
            if (result.SalesReport.length > 0) {
                $('#searchResultDiv').show();
            }
            else {
                $('#noResultDiv').show();
            }
            $.notify("Generated report Successfully!!", "success");
            $('#searchTable').DataTable();
        },
        error: function (error) {
            alert(JSON.stringify(error));
            $.notify("Error in generating report!!", "error");
        }
    });
}
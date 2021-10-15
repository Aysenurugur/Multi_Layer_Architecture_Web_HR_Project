$(document).ready(function () {
    $.ajax({
        url: "http://localhost:12430/api/Company/GetCompanyById/" + $("#companyId").val(),
        type: "GET",
        success: function (response) {
            console.log(response);
            $("#companyName").html(response.companyName);
        }
    })
})


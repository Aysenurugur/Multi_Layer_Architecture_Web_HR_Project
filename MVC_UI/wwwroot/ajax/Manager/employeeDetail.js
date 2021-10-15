$(document).ready(function () {
    $.ajax({
        url: "http://localhost:12430/api/User/GetUserById/"+ $("#employeeId").val(),
        type: "GET",
        success: function (response) {
            console.log(response);
            $("#employeeDetail").append(`<img src="/images/profile-user.png" alt="">
                                        <span>${response.firstName} ${response.lastName}</span>
                                        <span>${response.title}</span>
                                        <span><a href="" class="btn btn-danger">Pasifleştir</a></span>`);

            $("#firstName").val(response.firstName);
            $("#lastName").val(response.lastName);
            $("#title").val(response.title);
            $("#mail").val(response.email);
            $("#phoneNumber").val(response.phoneNumber);
            $("#startDate").val(response.hiredDate);
            $("#birthDate").val(response.birthDate);
        }
    })
})

$("#updateEmployee").click(function () {
    var updateUser = {
        id: $("#employeeId").val(),
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        title: $("#title").val(),
        email: $("#mail").val(),
        phoneNumber: $("#phoneNumber").val(),
        hiredDate: $("#startDate").val(),
        birthDate: $("#birthDate").val(),
    };
    $.ajax({
        url: "http://localhost:12430/api/User/UpdateUserInfo",
        type: "PUT",
        data: JSON.stringify(updateUser),
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            alert("success");
            console.log(response);
        }
    })
})
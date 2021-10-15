//Çalışanlar 
$(document).ready(function () {
    $.ajax({
        url: "http://localhost:12430/api/Company/GetEmployeesByCompanyId/" + $("#compId").val(),
        type: "GET",
        success: function (response) {
            console.log(response);
            response.map((item) => {
                var status = item.isActive ? 'A' : 'P';
                var statusColor = item.isActive ? 'btn-success' : 'btn-danger';

                $("#employees").append(`<a href="/Manager/EditEmployee/${item.id}" class="c-card width-100">
                                            <div class="c-card-header">
                                                <img src="/images/profile-user.png" alt="">
                                            </div>
                                            <div class="c-card-body">
                                                <span>${item.firstName} ${item.lastName}</span>
                                                <span>${item.title}</span>
                                                <span>${item.email}</span>
                                                <span>${item.phoneNumber}</span>
                                            </div>
                                        </a>`);

                $("#employeeTable").append(`<tr>
                                                <td><a href="/Manager/EditEmployee/${item.id}">${item.firstName} ${item.lastName}</a></td>
                                                <td>${item.title}</td>
                                                <td>${item.phoneNumber}</td>
                                                <td>${item.email}</td>
                                                <td><a id="empStatus" onclick=changeStatus(${item.id},${status}) class="btn ${statusColor}">${status}</a></td>
                                            </tr>`);

            })
        }
    })
})

//Çalışan ekleme 
$("#saveEmployee").click(function () {
    var employee = {
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        title: $("#title").val(),
        phoneNumber: $("#phoneNumber").val(),
        email: $("#mail").val(),
        birthDate: $("#birthDate").val(),
        hiredDate: $("#startDate").val(),
        companyId: $("#compId").val()
    }
    $.ajax({
        url: "http://localhost:12430/api/User/Add",
        type: "POST",
        data: JSON.stringify(employee),
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            alert("Success");
            console.log(response);
        },
        error: function (err) {
            console.log(err);
        }
    })
})
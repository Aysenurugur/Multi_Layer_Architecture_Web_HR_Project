//Register
$("#btnRegister").click(function () {
    var user = {
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        phoneNumber: $("#companyPhone").val(),
        email: $("#companyMail").val(),
        companyName: $("#companyName").val(),
        password: $("#password").val()
    }

    $.ajax({
        url: "http://localhost:12430/api/User/Register",
        type: "POST",
        data: JSON.stringify(user),
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            alert("Success");
            console.log(response);
        },
        error: function (err) {
            console.log(err);
        }
    })
});

//Login
$(document).ready(function () {
    $("#btnLogin").click(function () {
        var loginInfo = {
            email: $("#email").val(),
            password: $("#password").val()
        };
        $.ajax({
            url: "http://localhost:12430/api/User/Login",
            type: "POST",
            data: JSON.stringify(loginInfo),
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                console.log(response);
                window.location.href = "http://localhost:5000/Manager/Index/" + response.companyID;
            },
            error: function (err) {
                console.log(err);
            }
        })
    })
})


$(document).ready(function () {
    $.ajax({
        url: "http://localhost:12430/api/Comment/GetComments",
        type: 'GET',
        success: function (res) {
            res.map((item) => {
                $.ajax({
                    url: "http://localhost:12430/api/Company/GetCompanyById/" + item.companyId,
                    type: 'GET',
                    success: function (res) {
                        $('#random-comments').append(
                            `<div class="mySlides d-none">
                                <div class="d-flex flex-column jc-between">
                                    <img class="slide-logo" src="/images/kd_logo.png" alt="">
                                        <span class="slide-comment">
                                            ${item.content}
                                        </span>
                                        <div class="company-manager">
                                            <h1>${res.companyName}</h1>
                                            <span>Şirket Yöneticisi</span>
                                        </div>
                                </div>
                                </div>`)
                    }
                })

            });
            slider();
        }
    });

});

// Kullanıcı yorumları - yorumlar sayfası 
$(document).ready(function () {
    $.ajax({
        url: "http://localhost:12430/api/Comment/GetComments",
        type: "GET",
        success: function (response) {
            response.map((item) => {
                $.ajax({
                    url: "http://localhost:12430/api/Company/GetCompanyById/" + item.companyId,
                    type: "GET",
                    success: function (data) {
                        console.log(data);
                        var commentInfo = `<img class="card-image" src="https://media-cdn.t24.com.tr/media/library/2021/01/1611237404551-jasonnn.jpg" alt="">
                                        <div class="card-details">
                                            <div>
                                                <img class="card-logo mb-1" src="/images/kd_logo.png" alt="">
                                                <span class="card-title mb-2">3000+ Çalışan</span>
                                            </div>
                                            <h2 class="card-content my-4">${item.title}</h2>
                                            <button href="#" class="btn btn-primary" onclick="openDetail(${item.companyId})">İncele</button>
                                        </div>`;
                        $("#comments").append(commentInfo);
                    }
                });
            })
        }
    });
})

function openDetail(id) {
    window.location.href = "http://localhost:500/Guess/CommentDetail/" + id;
    $.ajax({
        url: "http://localhost:12430/api/Company/GetCommentByCompanyId/"+id,
        type: "GET",
        success: function (response) {
            $.ajax({
                url: "http://localhost:12430/api/Company/GetCompanyById/"+id,
                type: "GET",
                success: function (data) {
                    $("#commentTitle").html(response.title);
                    $("#commentContent").html(response.content);
                    $("#companyName").html(data.companyName);
                }
            })
        }
    })
}




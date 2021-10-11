$(function () {
    $.validator.setDefaults({
        errorClass: 'has-error',
        highlight: function (element) {
            $(element).addClass('error');
            $(element).next('label').addClass('error');
        },
        unhighlight: function (element) {
            $(element).removeClass('error');
            $(element).next('label').removeClass('error');
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        }
    })

    $.validator.methods.email = function (value, element) {
        return this.optional(element) || /^([a-zA-Z0-9_.-])+\@gmail.com$/.test(value);
    };

    $.validator.addMethod("strongPassword", function (value, element) {
        return this.optional(element)
            || value.length >= 8
            && /\d/.test(value)
            && /[A-Z]/i.test(value);
    }, "Şifreniz en az 8 karakter uzunluğunda olmalı ve en az bir rakam ve büyük harf içermelidir.")

    $.validator.addMethod("phoneTR", function (value, element) {
        return this.optional(element)
            || value.length == 10
            && /(05|5)[0-9][0-9][1-9]([0-9]){6}/.test(value)
    }, "Telefon numarasını başında 0 olmadan 10 karakter uzunluğunda boşluksuz giriniz.");

    $.validator.addMethod("nowhitespace", function (value, element) {
        return this.optional(element) || /^\S+$/i.test(value);
    }, "Boşluk bulunamaz.");

    $.validator.addMethod("lettersonly", function (value, element) {
        return this.optional(element) || /^\s*[a-zA-Z,ç,Ç,ğ,Ğ,ı,İ,ö,Ö,ş,Ş,ü,Ü,\s]+\s*$/i.test(value);
    }, "Sadece harf giriniz.");



    $('#register-form').validate({
        rules: {
            firstName: {
                required: true,
                nowhitespace: true,
                lettersonly: true,
                minlength: 3,
            },
            lastName: {
                required: true,
                nowhitespace: true,
                lettersonly: true,
                minlength: 3,
            },
            companyPhone: {
                required: true,
                phoneTR: true,
            },
            companyMail: {
                email: true,
                required: true,
                minlength: 13,
            },
            companyName: {
                required: true,
                minlength: 3,

            },
            password: {
                required: true,
                strongPassword: true,
            },
            
        },
        messages: {
            firstName: {
                required: "Adınızı giriniz.",
                minlength: "En az 3 karakterden oluşmalıdır.",
            },
            lastName: {
                required: "Soyadınızı giriniz.",
                minlength: "En az 3 karakterden oluşmalıdır.",
            },
            companyPhone: {
                required: "Telefon numarası giriniz."
            },
            companyMail: {
                email: "E-posta adresiniz ornek@gmail.com gibi olmalıdır.",
                required: "Kayıt olmak için e-posta adresi zorunludur.",
                minlength: "E-posta adresiniz en az 3 karakterden oluşmalıdır.",
            },
            companyName: {
                required: "Şirket adını giriniz",
                minlength: "En az üç karakterden oluşmalıdır."
            },
            password: {
                required: "Bu alan boş geçilemez.",
            }
        }
    });

    $('#adminEditCompanyForm').validate({
        rules: {
            firstName: {
                required: true,
                nowhitespace: true,
                lettersonly: true,
                minlength: 3,
            },
            lastName: {
                required: true,
                nowhitespace: true,
                lettersonly: true,
                minlength: 3,
            },
            companyMail: {
                email: true,
                required: true,
                minlength: 13,
            },

        },
        messages: {
            firstName: {
                required: "Adınızı giriniz.",
                minlength: "En az 3 karakterden oluşmalıdır.",
            },
            lastName: {
                required: "Soyadınızı giriniz.",
                minlength: "En az 3 karakterden oluşmalıdır.",
            },
            companyMail: {
                email: "E-posta adresiniz ornek-_.@gmail.com gibi olmalıdır.",
                required: "Kayıt olmak için e-posta adresi zorunludur.",
                minlength: "E-posta adresiniz en az 3 karakterden oluşmalıdır.",
            },
        }
    });

    $("#adminDescribingForm").validate({
        rules: {
            dayofftype: {
                required: true,
                lettersonly: true,
                minlength: 8,
                maxlength: 30,
            },
            dayyoffday: {
                required: true,                
            }

        },

        messages: {
            dayofftype: {
                required: "Alan boş geçilemez",
                minlength: "En az 8 karakterden oluşmalı",
                maxlength: "En fazla 30 karakterden oluşmalı",
            },
            dayoffday: {
                required: "Alan boş geçilemez",
            }
        }
    
    })
})
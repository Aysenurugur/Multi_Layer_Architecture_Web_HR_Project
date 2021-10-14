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
            let isFloatingLabel = element.closest('.floating-label');

            if (isFloatingLabel.length) {
                error.insertAfter(element.parent());
            }
            else {
                error.insertAfter(element);
            }
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

    $.validator.addMethod("minAge", function (value, element) {
        var today = new Date();
        var birthDate = new Date(value);
        var age = today.getFullYear() - birthDate.getFullYear();
        if (age > 19) { return true; }

        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) { age--; }

        return age >= 18;
    }, "Çalışan en az 18 yaşında olabilir.");

    $.validator.addMethod("greaterThanDate",
        function (value, element, params) {

            if (!/Invalid|NaN/.test(new Date(value))) {
                return new Date(value) > new Date($(params).val());
            }

            return isNaN(value) && isNaN($(params).val())
                || (Number(value) > Number($(params).val()));
        }, '{0} tarihinden geç tarih seçiniz.');

    $.validator.addMethod("greaterThanToday",
        function (value, element) {
            let today = new Date();
            let elementDateValue = new Date(value);
            return this.optional(element) || elementDateValue >= today;
            
        }, 'Bugünün tarihinden geç tarih seçiniz.');

    $.validator.addMethod("accept", function (value, element, param) {

        // Split mime on commas in case we have multiple types we can accept
        var typeParam = typeof param === "string" ? param.replace(/\s/g, "") : "image/*",
            optionalValue = this.optional(element),
            i, file, regex;

        // Element is optional
        if (optionalValue) {
            return optionalValue;
        }

        if ($(element).attr("type") === "file") {

            // Escape string to be used in the regex
            // see: https://stackoverflow.com/questions/3446170/escape-string-for-use-in-javascript-regex
            // Escape also "/*" as "/.*" as a wildcard
            typeParam = typeParam
                .replace(/[\-\[\]\/\{\}\(\)\+\?\.\\\^\$\|]/g, "\\$&")
                .replace(/,/g, "|")
                .replace(/\/\*/g, "/.*");

            // Check if the element has a FileList before checking each file
            if (element.files && element.files.length) {
                regex = new RegExp(".?(" + typeParam + ")$", "i");
                for (i = 0; i < element.files.length; i++) {
                    file = element.files[i];

                    // Grab the mimetype from the loaded file, verify it matches
                    if (!file.type.match(regex)) {
                        return false;
                    }
                }
            }
        }

        // Either return true because we've validated each file, or because the
        // browser does not support element.files and the FileList feature
        return true;
    }, $.validator.format("Please enter a value with a valid mimetype."));

    $.validator.addMethod("maxsize", function (value, element, param) {
        if (this.optional(element)) {
            return true;
        }

        if ($(element).attr("type") === "file") {
            if (element.files && element.files.length) {
                for (var i = 0; i < element.files.length; i++) {
                    if (element.files[i].size > param) {
                        return false;
                    }
                }
            }
        }

        return true;
    }, $.validator.format("File size must not exceed {0} bytes each."));

    //Guess Validations

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

    //Admin Validations

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
            },
            dayoffdescription: {
                required: false,
                minlength: 10,
                maxlength: 50,
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

    });

    //Manager Validations
    $("#managerAddEmployeeForm").validate({
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
            phoneNumber: {
                required: true,
                phoneTR: true,
            },
            mail: {
                email: true,
                required: true,
                minlength: 13,
            },
            companyName: {
                required: true,
                minlength: 3,

            },
            title: {
                required: true,
                maxlength: 30,
                lettersonly: true,
                
            },
            birthDate: {
                required: true,
                minAge: true,
            },
            startDate: {
                required: true,
            }
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
            phoneNumber: {
                required: "Telefon numarası giriniz."
            },
            mail: {
                email: "E-posta adresiniz ornek@gmail.com gibi olmalıdır.",
                required: "Bu alanı doldurmak zorunludur.",
                minlength: "E-posta adresiniz en az 3 karakterden oluşmalıdır.",
            },
            title: {
                required: "Bu alan boş geçilemez",
                maxlength: "En fazla 30 karakterden oluşmalıdır."
            },
            startDate: {
                required: "Bu alan boş geçilemez",
            }
        }

    });

    $('#managerEmployeeEditForm').validate({
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
            phoneNumber: {
                required: true,
                phoneTR: true,
            },
            mail: {
                email: true,
                required: true,
                minlength: 13,
            },
            companyName: {
                required: true,
                minlength: 3,

            },
            title: {
                required: true,
                maxlength: 30,
                lettersonly: true,

            },
            birthDate: {
                required: true,
                minAge: true,
            },
            startDate: {
                required: true,
            }
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
            phoneNumber: {
                required: "Telefon numarası giriniz."
            },
            mail: {
                email: "E-posta adresiniz ornek@gmail.com gibi olmalıdır.",
                required: "Bu alanı doldurmak zorunludur.",
                minlength: "E-posta adresiniz en az 3 karakterden oluşmalıdır.",
            },
            title: {
                required: "Bu alan boş geçilemez",
                maxlength: "En fazla 30 karakterden oluşmalıdır."
            },
            startDate: {
                required: "Bu alan boş geçilemez",
            }
        }
    });

    $('#managerRequestDenieForm').validate({
        rules: {
            description: {
                required: true,
                minlength: 10,
                maxlength: 100,
            }
        },

        messages: {
            required: "Bu alanı doldurmak zorunludur.",
            minlength: "En az 10 karakter uzunluğunda açıklama giriniz.",
            maxlength: "En fazla 100 karakter uzunluğunda açıklama giriniz.",
        }

    });

    $('#managerAddDebitForm').validate({
        rules: {
            category: {
                required: true,
            },
            serialNumber: {
                required: true,

            },
            givenDate: {
                required: true,
            },
            returnDate: {
                required: true,
                greaterThanDate: "#givenDate",
            },
            description: {
                required: true,
            }

        },
        messages: {
            category: {
                required: "Lütfen bir seçim yapınız",
            },
            serialNumber: {
                required: "Bir seri numarası giriniz.",
            },
            givenDate: {
                required: "Verilme tarihini giriniz.",
            },
            returnDate: {
                required: "Geri iade tarihini giriniz.",
            },
            description: {
                required: "Bir açıklama yazınız",
            }
        }
    });

    $('#managerAddBonusForm').validate({
        rules: {
            amountOfBonus: {
                required: true,
            },
            givenDate: {
                required: true,
                greaterThanToday: true,
            },
            description: {
                required: true,
            }
        },
        messages: {
            amountOfBonus: {
                required: "Lütfen verilen prim miktarını giriniz",
            },
            givenDate: {
                required: "Lütfen primin verildiği tarihi giriniz",
            },
            description: {
                required: "Lütfen prim açıklması giriniz",
            }
        }
    });

    $('#managerAddFileForm').validate({
        rules: {
            fileType: {
                required: true,
            },
            currentFile: {
                required: true,
                accept: "image/*,application/pdf",
                maxsize: 5242880,
            }
        },
        messages: {
            fileType: {
                required: "Yüklenecek dosya kategorisini seçin."
            },
            currentFile: {
                required: "Yüklenecek dosyayı seçin.",
                accept: "pdf, png, jpeg formatında dosya yükleyin.",
                maxsize: "5 MB'dan küçük dosyalar yükleyin",
            }
        }
    });

    $('#managerAddShiftBreakForm').validate({
        rules: {
            type: {
                required: true,
            },
            name: {
                required: true,
                minlength: 3,
                maxlength: 40,
                lettersonly: true,
            },
            startTime: {
                required: true,
            },
            endTime: {
                required: true,
            },
            description: {
                minlength: 10,
                maxlength: 40,
            }
        },
        messages: {
            type: {
                required: "Bir seçim yapın.",
            },
            name: {
                required: "İsimlendirme yapın.",
                minlength: "En az 3 karakterden oluşan bir isim girin.",
                maxlength: "İsimlendirme en fazla 40 karakterden oluşabilir.",
                lettersonly: "Sadece harf giriniz."
            },
            description: {
                minlength: "En az 10 karakterden oluşabilir.",
                maxlength: "En fazla 40 karakterden oluşabilir."
            },
        }
    });

    //TODO settings formunun validasyon ayalarını yap

    $('#managerSettingsForm').validate({
        rules: {

        },
        messages: {

        }
    });

    //Employee Validations

    $('#employeeDayoffRequestForm').validate({
        rules: {
            dayoffType: {
                required: true,
            },
            dayoffDay: {
                required: true,
            },
            startDate: {
                required: true,
                greaterThanToday: true,
            },
            endDate: {
                required: true,
                greaterThanDate: "#startDate",
            },
        },
        messages: {
            dayoffType: {
                required: "Bir izin türü seçiniz.",
            },
            dayoffDay: {
                required: "Kaç gün izin istediğinizi belirtiniz."
            },
            startDate: {
                required: "Başlangıç tarihi seçin.",
            },
            endDate: {
                required: "Bitiş tarihi seçiniz.",
            }

        }
    });

    $('#employeeDebitRejectForm').validate({
        rules: {

            description: {
                required: true,
                minlength: 20,
                maxlength: 100,
            },
        },
        messages: {
            description: {
                required: "Lütfen reddetme nedeninizi giriniz.",
                minlength: "En az 20 karakterden oluşmalıdır.",
                maxlength: "En fazla 100 karakterden oluşmalıdır.",
            },
        }
    });

    $('#employeeAddExpanseForm').validate({
        rules: {
            amountOfExpanse: {
                required: true,
            },
            expanseDate: {
                required: true,
            },
            expanseFiles: {
                required: true,
                maxsize: 10000000,
                accept: "image/*,application/pdf",
            },
            description: {
                required: true,
                minlength: 10,
                maxlength: 100,
            },
        },
        messages: {
            amountOfExpanse: {
                required: "Harcama miktarını giriniz."
            },
            expanseDate: {
                required: "Harcamanın yapıldığı tarihi giriniz",
            },
            expanseFiles: {
                required: "Harcamaya ilişkin dosyaları seçiniz.",
                maxsize: "Dosyaların boyunu 15 MB ve altında olmalıdır.",
                accept: "png|jpg|jpeg|pdf formatında dosya yükleyin."
            },
            description: {
                required: "Harcamayla ilgili açıklamayı giriniz.",
                minlength: "Açıklama en az 10 karakterden oluşmalıdır.",
                maxlength: "Açıklama en fazla 100 karakterden oluşmalıdır."
            },
        }
    })
})
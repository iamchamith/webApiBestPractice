/// <reference path="util.ts" />

module One.Authontication {


    var auth = (() => {

        var login = (e) => {
            $.ajax({
                url: '/token',
                data: e,
                method: 'post',
                contentType: 'application/x-www-form-urlencoded',
            }).done((e) => {
                
                sessionStorage.setItem('t', e.access_token);
                console.log(e);
                }).fail((e) => {
                   
                    Errors.handleErrors(e);
                });
        }

        return {

            init: () => {
                 
                $('#btnLogin').click(function () {
                    var d = {
                        username: $.trim($('#txtEmail').val()),
                        password: $('#txtPassword').val(),
                        grant_type: 'password'
                    };
                    login(d);
                });
            }
        };

    })();

    $(auth.init);
}
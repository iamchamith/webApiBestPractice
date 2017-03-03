 
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
                alert('login is success');
                }).fail((e) => {
                    alert('invalied username or password');
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

    export function init() {
        auth.init();
    }
}
module One.Authontication {


    var auth = (() => {

        var login = (e) => {
            $.ajax({
                url: '/token',
                data: JSON.stringify(e),
                method: 'post',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            }).done((e) => {
                console.log(e);
            });
        }

        return {

            init: () => {
                 
                $('#btnLogin').click(function () {
                    var d = {
                        username: $.trim($('#txtEmail').val()),
                        password: $('#txtPassword').val(),
                        grant_type: $('#txtPassword').val()
                    };
                    login(d);
                });
            }
        };

    })();

    $(auth.init);
}
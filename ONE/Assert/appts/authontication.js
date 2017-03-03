var One;
(function (One) {
    var Authontication;
    (function (Authontication) {
        var auth = (function () {
            var login = function (e) {
                $.ajax({
                    url: '/token',
                    data: e,
                    method: 'post',
                    contentType: 'application/x-www-form-urlencoded',
                }).done(function (e) {
                    sessionStorage.setItem('t', e.access_token);
                    console.log(e);
                    alert('login is success');
                }).fail(function (e) {
                    alert('invalied username or password');
                });
            };
            return {
                init: function () {
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
        function init() {
            auth.init();
        }
        Authontication.init = init;
    })(Authontication = One.Authontication || (One.Authontication = {}));
})(One || (One = {}));
//# sourceMappingURL=authontication.js.map
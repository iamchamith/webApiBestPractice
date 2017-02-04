var One;
(function (One) {
    var Authontication;
    (function (Authontication) {
        var auth = (function () {
            var login = function (e) {
                $.ajax({
                    url: '/token',
                    data: JSON.stringify(e),
                    method: 'post',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                }).done(function (e) {
                    console.log(e);
                });
            };
            return {
                init: function () {
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
    })(Authontication = One.Authontication || (One.Authontication = {}));
})(One || (One = {}));
//# sourceMappingURL=authontication.js.map
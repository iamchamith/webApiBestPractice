var Util;
(function (Util) {
    var Errors;
    (function (Errors) {
        function handleErrors(e) {
            if (e.status == 500) {
                sweetAlert("Oops...", "Something went wrong!", "error");
            }
            else if (e.status == 400) {
                console.log(e.responseJSON);
                var err = '<ul class="error-msg">';
                $.each(e.responseJSON.ModelState, function (i, d) {
                    err += "<li class='error-msg-li'>" + d[0] + "<li>";
                });
                err += '</ul><br/></br/>';
                swal({
                    title: "Invalied user inputs",
                    text: err,
                    html: true
                });
            }
            else if (e.status == 401) {
                alert('unauthorized location. click ok to go loging');
                window.location.replace("http://localhost:49036/ui/login");
            }
        }
        Errors.handleErrors = handleErrors;
        function logException(e, page) {
            console.log(e);
            try {
                $.ajax({
                    url: '/api/v0/error',
                    method: 'get',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({ page: page, stackTrace: e })
                }).done(function (e) {
                    console.log("===ERROR================");
                    console.log(e);
                    console.log("--------------------------");
                    console.log('error sent to the server');
                    console.log("===//ERROR================");
                });
            }
            catch (err) {
                console.log(err);
            }
        }
        Errors.logException = logException;
    })(Errors = Util.Errors || (Util.Errors = {}));
})(Util || (Util = {}));

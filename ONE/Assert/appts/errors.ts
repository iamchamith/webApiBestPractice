module Errors {

    export function handleErrors(e) {

        if (e.status == 500) { sweetAlert("Oops...", "Something went wrong!", "error"); }
        else if (e.status == 400) {
            console.log(e);
            var j = JSON.parse(e.responseJSON.Message);
            var err = '<ul class="error-msg">';
            $.each(j, (i, d) => {
                err += "<li class='error-msg-li'>" + d + "<li>";
            });
            err += '</ul><br/></br/>'
            swal({
                title: "Invalied user inputs",
                text: err,
                html: true
            });
        } else if (e.status == 401) {
            window.location.replace("http://localhost:49036/ui/login");
        }
    }
}
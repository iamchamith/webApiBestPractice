module Errors {

    export function handleErrors(e) {

        if (e.status == 500) { sweetAlert("Oops...", "Something went wrong!", "error"); }
        else if (e.status == 400) {
            console.log(e.responseJSON);
            var err = '<ul class="error-msg">';
            $.each(e.responseJSON.ModelState, (i, d) => {
                err += "<li class='error-msg-li'>" + d[0] + "<li>";
            });
            err += '</ul><br/></br/>'
            swal({
                title: "Invalied user inputs",
                text: err,
                html: true
            });
        } else if (e.status == 401) {
            alert('unauthorized location. click ok to go loging');
            window.location.replace("http://localhost:49036/ui/login");
        }
    }
}
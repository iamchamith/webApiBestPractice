function someFunction() {

    $("#btnClickMe").on('click mouseover', (e) => {
        alert('some' + e.type);
        //$(e.target).off('mouseover');// unbind only mouseOve
        //$(e.target).off();//unbiud all events

        //$(e.target).unbind('mouseover');// unbind only mouseOver
        //$(e.target).unbind();// unbind all

        // off > 1.7
        // unbind < 1.7
        // die < 1.7

    });
 
}


$(someFunction);
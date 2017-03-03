var Util;
(function (Util) {
    var Tools;
    (function (Tools) {
        function createCookie(name, value, days) {
            var expires;
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toDateString();
            }
            else {
                expires = "";
            }
            document.cookie = encodeURIComponent(name) + "=" + encodeURIComponent(value) + expires + "; path=/";
        }
        Tools.createCookie = createCookie;
        function readCookie(name) {
            var nameEQ = encodeURIComponent(name) + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) === ' ')
                    c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) === 0)
                    return decodeURIComponent(c.substring(nameEQ.length, c.length));
            }
            return null;
        }
        Tools.readCookie = readCookie;
        function addDays(date, days) {
            var result = new Date(date);
            result.setDate(result.getDate() + days);
            return result;
        }
        Tools.addDays = addDays;
        function encodeImageFileAsURL(file, callback) {
            var filesSelected = file;
            var fileReader = new FileReader();
            var fileToLoad = filesSelected[0];
            fileReader.onload = function (fileLoadedEvent) {
                callback({ f: fileLoadedEvent.target.result, ex: file[0].name.split('.').pop() });
            };
            fileReader.readAsDataURL(fileToLoad);
        }
        Tools.encodeImageFileAsURL = encodeImageFileAsURL;
    })(Tools = Util.Tools || (Util.Tools = {}));
})(Util || (Util = {}));
//# sourceMappingURL=tools.js.map
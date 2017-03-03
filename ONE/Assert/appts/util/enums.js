var Util;
(function (Util) {
    var Enums;
    (function (Enums) {
        (function (Crud) {
            Crud[Crud["insert"] = 0] = "insert";
            Crud[Crud["update"] = 1] = "update";
            Crud[Crud["delete"] = 2] = "delete";
            Crud[Crud["read"] = 3] = "read";
        })(Enums.Crud || (Enums.Crud = {}));
        var Crud = Enums.Crud;
    })(Enums = Util.Enums || (Util.Enums = {}));
})(Util || (Util = {}));
//# sourceMappingURL=enums.js.map
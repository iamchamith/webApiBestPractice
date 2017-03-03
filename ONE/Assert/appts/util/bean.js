var Util;
(function (Util) {
    var Bean;
    (function (Bean) {
        var GetQuery = (function () {
            function GetQuery(_skip, _take, _sortby, _isASC, _search) {
                this.skip = _skip;
                this.take = _take;
                this.sortBy = _sortby;
                this.isASC = _isASC;
                this.search = _search;
            }
            return GetQuery;
        }());
        Bean.GetQuery = GetQuery;
    })(Bean = Util.Bean || (Util.Bean = {}));
})(Util || (Util = {}));
//# sourceMappingURL=bean.js.map
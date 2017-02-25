var utilBean;
(function (utilBean) {
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
    utilBean.GetQuery = GetQuery;
})(utilBean || (utilBean = {}));
//# sourceMappingURL=utilBean.js.map
module utilBean {
    export class GetQuery {
        constructor(_skip: number, _take: number, _sortby: string, _isASC: boolean, _search: string) {
            this.skip = _skip;
            this.take = _take;
            this.sortBy = _sortby;
            this.isASC = _isASC;
            this.search = _search;
        }
        skip: number;
        take: number;
        sortBy: string;
        isASC: boolean;
        search: string;
    }
}
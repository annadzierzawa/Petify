export class Page<T> {
    totalCount: number;
    pageNumber: number;
    pageSize: number;
    items: Array<T>;
}

export interface SearchCriteria {
    pageNumber: number;
    orderBy?: string;
    pageSize?: number;
}

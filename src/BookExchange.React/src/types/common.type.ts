export declare module Common {
  export type PaginatedResult<T> = {
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    totalRecords: number;
    data: T[];
  };
}

export declare module Common {
  export type PaginatedResult<T> = {
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    totalRecords: number;
    data: T[];
  };

  export type PaginationFilter = {
    [key: string]: any;

    pageNumber?: number;
    pageSize?: number;
    sortDirection?: string;
    sortBy?: string;
  };
}

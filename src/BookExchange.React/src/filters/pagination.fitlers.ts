export interface PaginationFilter {
  [key: string]: any;

  pageNumber?: number;
  pageSize?: number;
  sortDirection?: string;
  sortBy?: string;
}

import { PaginationFilter } from "./pagination.fitlers";

export interface PostsFilter extends PaginationFilter {
  [key: string]: any;

  includePostedBy?: boolean;
  includeCondition?: boolean;
  includeBook?: boolean;
  status?: string;
  bookId?: number;
  conditionId?: number;
  timeAdded?: Date;
}

// todo: check dependencies and remove this module (transfered to /types)

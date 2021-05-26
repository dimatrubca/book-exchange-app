import { fetchApi } from "./fetchApi";
import { ServiceUtils } from "../utils";
import { Common, Wishlist } from "../types";

const GetAll = async (filter: Wishlist.WishlistFilter) => {
  const query = ServiceUtils.objectToQueryString(filter);
  console.log(query);

  return fetchApi<Common.PaginatedResult<Wishlist.Wishlist>>(
    "/wishlist?" + query
  );
};

const WishlistService = {
  GetAll,
};

export { WishlistService };

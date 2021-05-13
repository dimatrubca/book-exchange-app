const fetchApi = <TResponse>(
  url: string,
  config: any = {}
): Promise<TResponse> => {
  if (!config) config = {};
  if (!config.hasOwnProperty("headers")) {
    config.headers = {};
  }
  config.headers["Authorization"] = getUserToken();

  return fetch(`https://localhost:5001/api${url}`, config)
    .then((response) => response.json())
    .then((data) => data);
};

const getUserToken = (): string => {
  return "Bearer " + localStorage.getItem("token");
};

export { fetchApi };

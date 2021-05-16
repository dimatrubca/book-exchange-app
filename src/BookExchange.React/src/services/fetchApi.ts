const fetchApi = <TResponse>(
  url: string,
  config: any = {}
): Promise<TResponse> => {
  if (!config) config = {};
  if (!config.hasOwnProperty("headers")) {
    config.headers = {};
  }
  config.headers["Authorization"] = getUserToken();

  console.log("config: ", config);
  return fetch(`https://localhost:5001/api${url}`, config)
    .then((res) => {
      if (!res.ok) {
        return res.text().then((text) => {
          throw Error(text);
        });
      } else {
        return res.text();
      }
    })
    .then((data) => (data ? JSON.parse(data) : {}));
};

const getUserToken = (): string => {
  return "Bearer " + localStorage.getItem("token");
};

export { fetchApi };

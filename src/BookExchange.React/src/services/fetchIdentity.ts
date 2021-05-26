const fetchIdentity = <TResponse>(
  url: string,
  config: any = {}
): Promise<TResponse> => {
  return fetch(`https://localhost:5001${url}`, config)
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

export { fetchIdentity };

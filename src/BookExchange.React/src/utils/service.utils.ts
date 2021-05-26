const objectToQueryParams = (obj: any) => {
  var result = "";
  for (var key in obj) {
    if (key != "") {
      result += "&";
    }

    result += key + "=" + encodeURIComponent(obj[key]);
  }
};

const objectToQueryString = (params: any) => {
  var esc = encodeURIComponent;
  return Object.keys(params)
    .filter((k) => {
      if (!params[k]) return false;
      return true;
    })
    .map((k) => {
      if (Array.isArray(params[k])) {
        let result = "";
        for (let item of params[k]) {
          if (result !== "") result = "&" + result;
          result += esc(k) + "=" + esc(item["id"]);
        }
        return result;
      }

      return esc(k) + "=" + esc(params[k]);
    })
    .join("&");
};

const ServiceUtils = {
  objectToQueryString,
};

export { ServiceUtils };

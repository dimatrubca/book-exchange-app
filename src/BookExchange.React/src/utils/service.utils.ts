const objectToQueryParams = (obj: any) => {
  var result = "";
  for (var key in obj) {
    if (key != "") {
      result += "&";
    }

    result += key + "=" + encodeURIComponent(obj[key]);
  }
};

export {};

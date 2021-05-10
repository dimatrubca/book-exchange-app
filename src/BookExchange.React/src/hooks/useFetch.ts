import { useState } from "react";

const useFetch = <T>(service: (args: any) => Promise<T>) => {
  const [isLoading, setLoading] = useState(false);
  const [data, setData] = useState<T>();

  const fetch = async (...args: any) => {
    try {
      setLoading(true);

      const response = await service(args);

      setData(response);
    } catch (error) {
      console.log("Error", error);
    } finally {
      setLoading(false);
    }
  };

  return { isLoading, data, fetch };
};

export { useFetch };

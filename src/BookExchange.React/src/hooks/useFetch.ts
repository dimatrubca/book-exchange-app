import { useCallback, useState } from "react";
import { useSnackbar } from "notistack";

const useFetch = <T>(service: (...args: any[]) => Promise<T>) => {
  const { enqueueSnackbar } = useSnackbar();

  const [isLoading, setLoading] = useState(false);
  const [data, setData] = useState<T>();

  const fetch = useCallback(
    async (...args: any[]) => {
      try {
        setLoading(true);

        const response = await service(...args);

        setData(response);
      } catch (error) {
        console.log("Error", error);
        enqueueSnackbar(error.message, { variant: "error" });
      } finally {
        setLoading(false);
      }
    },
    [service, enqueueSnackbar]
  );
  return { isLoading, data, fetch };
};
export { useFetch };

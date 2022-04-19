import { useCallback, useState } from "react";

function useFetchData() {
  const [fetchStatus, setFetchStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");

  const fetchData = useCallback(async () => {
    try {
      setFetchStatus("loading");
      await fetch("https:/www.google.com");
      setFetchStatus("success");
    } catch (error) {
      setFetchStatus("error");
    }
  }, []);

  return {
    fetchData,
    status: fetchStatus,
  };
}

export default useFetchData;
import { useEffect, useState } from "react";

const useIsBigScreen = () => {
  const [isBig, setIsBig] = useState<boolean>(false);

  useEffect(() => {
    const resizeListener = () => {
      const width = window.innerWidth;
      setIsBig(width < 600);
      console.log("resize: ", width);
    };

    window.addEventListener("resize", resizeListener);

    return () => {
      window.removeEventListener("resize", resizeListener);
    };
  }, []);

  return isBig;
};

export default useIsBigScreen;

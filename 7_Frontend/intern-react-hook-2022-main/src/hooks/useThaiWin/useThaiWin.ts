import { useCallback, useEffect, useState } from "react";
import enterThaiWin from "../../api/enterThaiWin";
import exitThaiWin from "../../api/exitThaiWin";
const useThaiWin = () => {
  const [isLogin, setIsLogin] = useState<boolean>(false);

  useEffect(() => {
    return () => {
      setIsLogin(false);
      exitThaiWin();
    };
  }, []);

  const enter = () => {
    if (!isLogin) {
      setIsLogin(true);
      enterThaiWin();
    }
  };

  const exit = () => {
    if (isLogin) {
      setIsLogin(false);
      exitThaiWin();
    }
  };

  return [isLogin, enter, exit] as const;
};

export default useThaiWin;

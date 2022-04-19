import { useEffect } from "react";

type Props = {
  checkCount: number;
};
const UseEffectExample = ({ checkCount }: Props) => {
  useEffect(() => {
    if (checkCount > 2) {
      console.log("> 2, sent to server");
      return () => {
        console.log("CLEAN Effect!!");
      };
    }
  }, [checkCount]);

  return <div></div>;
};

export default UseEffectExample;

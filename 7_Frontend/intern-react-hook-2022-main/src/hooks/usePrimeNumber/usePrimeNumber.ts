import { useState } from "react";

const usePrimeNumber = () => {
  const [number, setNumber] = useState<Number>(0);
  const [isPrime, setIsPrime] = useState<Boolean>(false);

  function checkPrime(num: number) {
    setIsPrime(true);
    setNumber(num);
    if (num <= 1) {
      setIsPrime(false);
    } else {
      for (let i = 2; i < num; i++) {
        if (num % i == 0) {
          setIsPrime(false);
          break;
        }
      }
    }
  }

  return [isPrime, (num: number) => checkPrime(num), number] as const;
};

export default usePrimeNumber;

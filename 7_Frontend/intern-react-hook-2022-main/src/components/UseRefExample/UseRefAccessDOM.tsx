import { useEffect, useRef, useState } from "react";

function UseRefAccessDOM() {
  const [count, setCount] = useState<number>(0);
  const divRef = useRef<HTMLDivElement>(null);

  const increase = () => {
    setCount((c) => c + 1);
  };

  useEffect(() => {
    if (divRef.current && count > 3)
        divRef.current.style.background = 'red'
  }, [count])

  return (
    <div ref={divRef}>

      <p>Count is: {count}</p>
      <div>
        <button onClick={increase}>Plus + 1</button>
      </div>
    </div>
  );
}

export default UseRefAccessDOM;

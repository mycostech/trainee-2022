import { useState } from "react";
import UseEffectExample from "../UseEffectExample/UseEffectExample";

function UseStateExample() {
  const [count, setCount] = useState<number>(0);

  const increase = () => {
    setCount((p) => p + 1);
  };

  return (
    <div>
      <p>Count is: {count}</p>
      <div>
        <button onClick={increase}>Plus + 1</button>
      </div>
      <UseEffectExample checkCount={count} />
    </div>
  );
}

export default UseStateExample;

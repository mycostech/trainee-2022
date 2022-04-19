import { useState } from "react";
import TODO from "./TODO";

function UseCallbackExample() {
  const [count, setCount] = useState<number>(0);
  const [todos, setTodo] = useState<string[]>([
    "Before Yesterday",
    "Yesterday",
  ]);

  const increase = () => {
    setCount((p) => p + 1);
  };

  const addTodo = () => {
      setTodo(p => [...p, 'Today'])
  }

  return (
    <div>
      <TODO todos={todos} addTodo={addTodo} />
      <p>Count is: {count}</p>
      <div>
        <button onClick={increase}>Plus + 1</button>
      </div>
    </div>
  );
}

export default UseCallbackExample;
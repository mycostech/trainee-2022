import { memo } from "react";

interface TOROProps {
  todos: string[];
  addTodo: VoidFunction;
}

function TODO({ todos, addTodo }: TOROProps) {
  console.log("TODO RE-RENDER");
  return (
    <div>
      {todos.map((m) => (
        <p key={m}>{m}</p>
      ))}

      <button onClick={addTodo}>
          add todo
      </button>
    </div>
  );
}

export default memo(TODO)

import React from "react";
import { dateToString, dateToTimeString } from "../../helpers/dateFormat";
import { ToDoContext } from "../../contexts/ToDoContext";

export default function ToDoList({ todos }) {
  return (
    <>
      <div className="todo-list-wrapper">
        {todos.map((todo) => (
          <ToDoItem key={todo.id} todo={todo} />
        ))}
      </div>
    </>
  );
}

function ToDoItem({ todo }) {
  const { currentTodo, setCurrentTodo } = React.useContext(ToDoContext);

  return (
    <>
      <div className="todo-list-item" onClick={() => setCurrentTodo(todo)}>
        <div className="content">
          <div className="title">{todo.title || ""}</div>
          <div className="description">{todo.description || ""}</div>
        </div>
        <div className="date-time">
          <div>{dateToString(new Date(todo.limitedAt))}</div>
          <div>{dateToTimeString(new Date(todo.limitedAt))}</div>
        </div>
      </div>
    </>
  );
}

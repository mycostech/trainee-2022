import React from "react";
import { dateToString } from "../../helpers/dateFormat";

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
  return (
    <>
      <div className="todo-list-item">
        <div className="content">
          <div className="title">{todo.title || ""}</div>
          <div className="description">{todo.description || ""}</div>
        </div>
        <div className="date-time">
          <div>{dateToString(new Date(todo.limitedAt))}</div>
          <div>{new Date(todo.limitedAt).toLocaleTimeString()}</div>
        </div>
      </div>
    </>
  );
}

import React from "react";
import { dateToString, dateToTimeString } from "../../helpers/dateFormat";
import { ToDoContext } from "../../contexts/ToDoContext";
import toast from "react-hot-toast";

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
      <div
        className="todo-list-item"
        onClick={() => {
          setCurrentTodo(todo);
          toast(`${todo.title} selected`, { type: "success" });
        }}
        style={{
          backgroundColor: todo.isCompleted ? "#61db65" : todo.priority == "low" ? "white" : todo.priority == "medium" ? "#ff9900" : "#ff5c5c",
        }}
      >
        <div className="content">
          <div
            className="title"
            style={{
              textDecoration: todo.isCompleted ? "line-through" : "none",
            }}
          >
            {todo.title || ""}
          </div>
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

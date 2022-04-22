import React from "react";
import ToDoInfo from "./partials/ToDoInfo";
import ToDoList from "./partials/ToDoList";
import { AiOutlinePlusCircle } from "react-icons/ai";
import Pagination from "./partials/Pagination";
import { ToDoContext } from "../contexts/ToDoContext";

export default function ToDoContainer({ props }) {
  const { todos, totalTodos, totalCompletedTodos, currentPage, amountPerPage, setCurrentPage } = props;

  const { currentTodo, setCurrentTodo } = React.useContext(ToDoContext);

  return (
    <>
      <div className="todo-container">
        <ToDoInfo />
        <div className="todo-list">
          <h1>TODO LIST</h1>
          {todos && <ToDoList todos={todos} />}
          <div className="footer">
            <div className="complete">
              COMPLETED <span className="circle-text">{totalCompletedTodos}</span>
            </div>
            <div className="add-todo-button" onClick={() => setCurrentTodo(null)}>
              <AiOutlinePlusCircle />
            </div>
          </div>
          <Pagination numberOfPages={Math.ceil(totalTodos / amountPerPage)} currentPage={currentPage} setCurrentPage={setCurrentPage} />
        </div>
      </div>
    </>
  );
}

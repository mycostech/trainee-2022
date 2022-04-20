import React from "react";
import ToDoInfo from "./partials/ToDoInfo";
import ToDoList from "./partials/ToDoList";
import { AiOutlinePlusCircle } from "react-icons/ai";

export default function ToDoContainer() {
  return (
    <>
      <div className="todo-container">
        <ToDoInfo />
        <div className="todo-list">
          <h1>TODO LIST</h1>
          <ToDoList />
          <div className="footer">
            <div className="complete">
              COMPLETED <span className="circle-text">2</span>
            </div>
            <div className="add-todo-button">
              <AiOutlinePlusCircle />
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

import React from "react";

export default function ToDoList() {
  return (
    <>
      <div className="todo-list-wrapper">
        <ToDoItem />
        <ToDoItem />
        <ToDoItem />
        <ToDoItem />
      </div>
    </>
  );
}

function ToDoItem() {
  return (
    <>
      <div className="todo-list-item">
        <div className="content">
          <div className="title">Example</div>
          <div className="description">Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis provident ratione dolorum </div>
        </div>
        <div className="date-time">
          <div>19 Mar 2022</div>
          <div>12:00 PM</div>
        </div>
      </div>
    </>
  );
}

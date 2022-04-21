import React from "react";
import ToDoForm from "./partials/ToDoForm";
import { HiOutlineDocumentText } from "react-icons/hi";

export default function ToDoAddItem({ fetchData }) {
  return (
    <>
      <div className="todo-add-item">
        <div className="todo-add-item__header">
          <h1>Add New Thing</h1>
          <div>
            <HiOutlineDocumentText />
          </div>
        </div>
        <ToDoForm fetchData={fetchData} />
      </div>
    </>
  );
}

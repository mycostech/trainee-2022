import React from "react";
import ToDoForm from "./partials/ToDoForm";
import { HiOutlineDocumentText } from "react-icons/hi";
import { BsPencilSquare } from "react-icons/bs";
import { ToDoContext } from "../contexts/ToDoContext";

export default function ToDoItem({ formType, fetchData }) {
  const { currentTodo, setCurrentTodo } = React.useContext(ToDoContext);

  return (
    <>
      <div className="todo-item">
        <div className="todo-item__header">
          <h1>{formType === "ADD" ? "Add New Thing" : `Edit ${currentTodo?.title}`}</h1>
          <div>{formType === "ADD" ? <HiOutlineDocumentText /> : <BsPencilSquare />}</div>
        </div>
        <ToDoForm formType={formType} fetchData={fetchData} />
      </div>
    </>
  );
}

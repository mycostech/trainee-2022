import React, { useEffect, useState } from "react";
import ToDoInfo from "./partials/ToDoInfo";
import ToDoList from "./partials/ToDoList";
import { AiOutlinePlusCircle } from "react-icons/ai";
import Pagination from "./partials/Pagination";
import { axiosHelper } from "../helpers/axiosHelper";

export default function ToDoContainer() {
  const amountPerPage = 4;

  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    async function fetchData() {
      const response = await axiosHelper.get(
        `/api/task/get/${(currentPage - 1) * amountPerPage + 1}/${(currentPage - 1) * amountPerPage + amountPerPage}`
      );
      console.log(response.data);
    }
    fetchData();
  }, [currentPage]);

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
          <Pagination numberOfPages={5} currentPage={currentPage} setCurrentPage={setCurrentPage} />
        </div>
      </div>
    </>
  );
}

import React, { useEffect, useState } from "react";
import ToDoInfo from "./partials/ToDoInfo";
import ToDoList from "./partials/ToDoList";
import { AiOutlinePlusCircle } from "react-icons/ai";
import Pagination from "./partials/Pagination";
import { axiosHelper } from "../helpers/axiosHelper";

export default function ToDoContainer() {
  const amountPerPage = 4;

  const [currentPage, setCurrentPage] = useState(1);
  const [todos, setTodos] = useState([]);
  const [totalTodos, setTotalTodos] = useState(0);
  const [totalCompletedTodos, setTotalCompletedTodos] = useState(0);

  useEffect(() => {
    async function fetchData() {
      let response = await axiosHelper.get("/api/task/getTaskCount");
      if (response.status === 200) setTotalTodos(response.data.object);
      else console.log(response.data.message);
      response = await axiosHelper.get(
        `/api/task/getTaskFromTo/${(currentPage - 1) * amountPerPage + 1}/${(currentPage - 1) * amountPerPage + amountPerPage}`
      );
      if (response.status === 200) setTodos(response.data.object);
      else console.log(response.data.message);
      response = await axiosHelper.get("/api/task/getCompletedTaskCount");
      if (response.status === 200) setTotalCompletedTodos(response.data.object);
      else console.log(response.data.message);
    }
    fetchData();
  }, [currentPage, totalTodos, totalCompletedTodos]);

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
            <div className="add-todo-button">
              <AiOutlinePlusCircle />
            </div>
          </div>
          <Pagination numberOfPages={Math.ceil(totalTodos / amountPerPage)} currentPage={currentPage} setCurrentPage={setCurrentPage} />
        </div>
      </div>
    </>
  );
}

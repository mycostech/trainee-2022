import React, { useEffect, useState } from "react";
import ToDoContainer from "../components/ToDoContainer";
import ToDoAddItem from "../components/ToDoAddItem";
import { axiosHelper } from "../helpers/axiosHelper";

export default function Dashboard() {
  const amountPerPage = 4;

  const [currentPage, setCurrentPage] = useState(1);
  const [todos, setTodos] = useState([]);
  const [totalTodos, setTotalTodos] = useState(0);
  const [totalCompletedTodos, setTotalCompletedTodos] = useState(0);

  useEffect(() => {
    fetchData();
  }, [currentPage, totalTodos, totalCompletedTodos]);

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

  return (
    <>
      <div className="dashboard">
        <ToDoContainer
          props={{
            todos,
            totalTodos,
            totalCompletedTodos,
            currentPage,
            amountPerPage,
            setCurrentPage,
          }}
        />
        <ToDoAddItem fetchData={fetchData} />
      </div>
    </>
  );
}

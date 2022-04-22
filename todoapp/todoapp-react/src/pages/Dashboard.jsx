import React, { useEffect, useState, useMemo } from "react";
import ToDoContainer from "../components/ToDoContainer";
import ToDoItem from "../components/ToDoItem";
import { axiosHelper } from "../helpers/axiosHelper";
import { ToDoContext } from "../contexts/ToDoContext";

export default function Dashboard() {
  const amountPerPage = 4;

  const [currentPage, setCurrentPage] = useState(1);
  const [todos, setTodos] = useState([]);
  const [totalTodos, setTotalTodos] = useState(0);
  const [totalCompletedTodos, setTotalCompletedTodos] = useState(0);
  const [currentTodo, setCurrentTodo] = useState(null);

  const contextValue = useMemo(() => ({ currentTodo, setCurrentTodo }), [currentTodo]);

  useEffect(() => {
    fetchData();
  }, []);

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
        <ToDoContext.Provider value={contextValue}>
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
          {!currentTodo ? <ToDoItem formType={"ADD"} fetchData={fetchData} /> : <ToDoItem formType={"EDIT"} fetchData={fetchData} />}
        </ToDoContext.Provider>
      </div>
    </>
  );
}

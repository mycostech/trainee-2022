import React, { useState } from "react";
import { BsPencil } from "react-icons/bs";
import Select from "react-select";
import { isCompletedOptions, statusOptions, priorityOptions } from "./todoOptions";
import toast from "react-hot-toast";
import { axiosHelper } from "../../helpers/axiosHelper";

export default function ToDoForm({ fetchData }) {
  const [title, setTitle] = useState(null);
  const [description, setDescription] = useState(null);
  const [date, setDate] = useState(null);
  const [time, setTime] = useState(null);
  const [isCompleted, setIsCompleted] = useState(isCompletedOptions[0]);
  const [status, setStatus] = useState(statusOptions[0]);
  const [priority, setPriority] = useState(priorityOptions[0]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!title) {
      toast.error("Title is required");
      return;
    }
    axiosHelper
      .post("/api/task/create", {
        title,
        description,
        date,
        time,
        isCompleted: isCompleted.value,
        status: status.value,
        priority: priority.value,
      })
      .then((res) => {
        if (res.data.success) {
          toast.success(res.data.message);
          setTitle(null);
          setDescription(null);
          setDate(null);
          setTime(null);
          setIsCompleted(isCompletedOptions[0]);
          setStatus(statusOptions[0]);
          setPriority(priorityOptions[0]);
          fetchData();
        } else {
          toast.error(res.data.message);
        }
      });
  };

  return (
    <>
      <div className="todo-form">
        <form onSubmit={handleSubmit}>
          <input type="text" placeholder="Title" required onChange={(e) => setTitle(e.target.value)} />
          <input type="text" placeholder="Description" onChange={(e) => setDescription(e.target.value)} />
          <input
            type="text"
            onFocus={(e) => (e.currentTarget.type = "date")}
            onBlur={(e) => (e.currentTarget.type = "text")}
            placeholder="Due Date"
            onChange={(e) => setDate(e.target.value)}
          />
          <input
            type="text"
            onFocus={(e) => (e.currentTarget.type = "time")}
            onBlur={(e) => (e.currentTarget.type = "text")}
            placeholder="Due Time"
            onChange={(e) => setTime(e.target.value)}
          />
          <Selector name="Is Completed" options={isCompletedOptions} onChange={setIsCompleted} />
          <Selector name="Status" options={statusOptions} onChange={setStatus} />
          <Selector name="Priority" options={priorityOptions} onChange={setPriority} />
          <button onClick={handleSubmit}>
            ADD YOUR THING <BsPencil />
          </button>
        </form>
      </div>
    </>
  );
}

function Selector({ name, options, onChange }) {
  return (
    <div>
      <div>{name}</div>
      <Select
        defaultValue={options[0]}
        options={options}
        onChange={onChange}
        styles={{
          option: (base, state) => ({
            ...base,
            color: state.isSelected ? "#fff" : "#000",
          }),
        }}
      />
    </div>
  );
}

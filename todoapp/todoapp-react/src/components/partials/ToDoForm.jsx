import React, { useEffect, useState } from "react";
import { BsPencil, BsTrash } from "react-icons/bs";
import Select from "react-select";
import { isCompletedOptions, priorityOptions } from "./todoOptions";
import toast from "react-hot-toast";
import { axiosHelper } from "../../helpers/axiosHelper";
import { ToDoContext } from "../../contexts/ToDoContext";
import { dateToString, dateToTimeString } from "../../helpers/dateFormat";

export default function TodoForm({ formType, fetchData }) {
  const { currentTodo, setCurrentTodo } = React.useContext(ToDoContext);

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [date, setDate] = useState("");
  const [time, setTime] = useState("");
  const [isCompleted, setIsCompleted] = useState(isCompletedOptions[0]);
  const [priority, setPriority] = useState(priorityOptions[0]);

  useEffect(() => {
    if (currentTodo) {
      setTitle(currentTodo.title);
      setDescription(currentTodo.description);
      setDate(dateToString(new Date(currentTodo.limitedAt)));
      setTime(dateToTimeString(new Date(currentTodo.limitedAt)));
      setIsCompleted(isCompletedOptions.find((option) => option.value === currentTodo.isCompleted));
      setPriority(priorityOptions.find((option) => option.value === currentTodo.priority));
    } else {
      setTitle("");
      setDescription("");
      setDate("");
      setTime("");
      setIsCompleted(isCompletedOptions[0]);
      setPriority(priorityOptions[0]);
    }
  }, [currentTodo]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!title) {
      toast.error("Title is required");
      return;
    }
    if (formType == "ADD") {
      addTask();
    } else {
      editTask();
    }
  };

  const addTask = () => {
    axiosHelper
      .post("/api/task/create", {
        title,
        description,
        limitedAt: new Date(date + " " + time),
        isCompleted: isCompleted.value,
        priority: priority.value,
      })
      .then((res) => {
        if (res.data.success) {
          toast.success(res.data.message);
          setTitle("");
          setDescription("");
          setDate("");
          setTime("");
          setIsCompleted(isCompletedOptions[0]);
          setPriority(priorityOptions[0]);
          fetchData();
        } else {
          toast.error(res.data.message);
        }
      });
  };

  const editTask = () => {
    axiosHelper
      .post("/api/task/update", {
        id: currentTodo.id,
        title,
        description,
        limitedAt: new Date(date + " " + time),
        isCompleted: isCompleted.value,
        priority: priority.value,
      })
      .then((res) => {
        if (res.data.success) {
          toast.success(res.data.message);
          setTitle("");
          setDescription("");
          setDate("");
          setTime("");
          setIsCompleted(isCompletedOptions[0]);
          setPriority(priorityOptions[0]);
          fetchData();
        } else {
          toast.error(res.data.message);
        }
      });
  };

  const handleDelete = () => {
    axiosHelper
      .post("/api/task/delete", {
        id: currentTodo.id,
      })
      .then((res) => {
        if (res.data.success) {
          toast.success(res.data.message);
          setTitle("");
          setDescription("");
          setDate("");
          setTime("");
          setIsCompleted(isCompletedOptions[0]);
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
          <input type="text" placeholder="Title" required onChange={(e) => setTitle(e.target.value)} value={title} />
          <input type="text" placeholder="Description" onChange={(e) => setDescription(e.target.value)} value={description} />
          <input
            type="text"
            onFocus={(e) => (e.currentTarget.type = "date")}
            onBlur={(e) => (e.currentTarget.type = "text")}
            placeholder="Due Date"
            onChange={(e) => setDate(e.target.value)}
            value={date}
          />
          <input
            type="text"
            onFocus={(e) => (e.currentTarget.type = "time")}
            onBlur={(e) => (e.currentTarget.type = "text")}
            placeholder="Due Time"
            onChange={(e) => setTime(e.target.value)}
            value={time}
          />
          <Selector name="Is Completed" options={isCompletedOptions} onChange={setIsCompleted} value={isCompleted} />
          <Selector name="Priority" options={priorityOptions} onChange={setPriority} value={priority} />
          <button type="button" style={{ background: "#ed4646" }} onClick={handleDelete}>
            DELETE YOUR THING <BsTrash />
          </button>
          <button type="submit" onClick={handleSubmit}>
            SAVE YOUR THING <BsPencil />
          </button>
        </form>
      </div>
    </>
  );
}

function Selector({ name, options, onChange, value }) {
  return (
    <div>
      <div>{name}</div>
      <Select
        defaultValue={value ? value : options[0]}
        options={options}
        onChange={onChange}
        value={value}
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

import React from "react";
import { dateToString } from "../../helpers/dateFormat";
import { CircularProgressbar, buildStyles } from "react-circular-progressbar";

export default function ToDoInfo({ totalTodos, totalCompletedTodos }) {
  const percentage = totalTodos ? Math.round((totalCompletedTodos / totalTodos) * 100) : 0;
  return (
    <>
      <div className="todo-info">
        <div className="todo-info-left">
          <h1>
            Your <br />
            Lists
          </h1>
          <span>{dateToString(new Date())}</span>
        </div>
        <div className="todo-info-right">
          <div style={{ width: "60%" }}>
            <CircularProgressbar
              value={percentage}
              text={`${percentage}%`}
              styles={buildStyles({
                strokeLinecap: "butt",
                textSize: "16px",
                pathTransitionDuration: 0.5,
                pathColor: `#4d91ff`,
                textColor: "#fff",
                trailColor: "#fff",
                backgroundColor: "#3e98c7",
              })}
            />
          </div>
        </div>
      </div>
    </>
  );
}

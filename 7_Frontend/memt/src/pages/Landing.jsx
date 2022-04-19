import React from "react";
import { Link } from "react-router-dom";

export default function Landing() {
  return (
    <>
      <div className="landing">
        <div className="landing-image">
          <img src="/images/landing.png" alt="" />
        </div>
        <div className="landing-form">
          <div className="landing-form-logo">
            <img src="/images/mycos-logo.png" alt="" />
          </div>
          <div className="landing-form-header">
            <h1>MEMT</h1>
            <h2>Mycos Employee Mood Tracker</h2>
          </div>
          <Link to="/member">
            <button>Login</button>
          </Link>
        </div>
      </div>
    </>
  );
}

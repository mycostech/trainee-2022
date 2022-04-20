import React from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import toast from "react-hot-toast";

export default function Landing() {
  const { currentUser } = useAuth();
  if (currentUser) {
    toast.success("Welcome Back!" + currentUser.email);
    setInterval(() => {
      window.location.href = "/member";
    }, 1000);
  }
  return (
    <>
      <div className="landing">
        <div className="landing-image">
          <img src="/images/landing.png" alt="" />
        </div>
        <div className="landing-form">
          <div className="landing-form-logo">
            <img src="/images/logo.png" alt="" />
          </div>
          <div className="landing-form-header">
            <h1>ThisGameZ</h1>
            <h2>TODO APP</h2>
          </div>
          <Link to="/login">
            <button>Login</button>
          </Link>
        </div>
      </div>
    </>
  );
}

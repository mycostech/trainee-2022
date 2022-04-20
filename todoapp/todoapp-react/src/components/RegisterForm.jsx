import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";

export default function LoginForm() {
  const navigate = useNavigate();

  const [email, setemail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const { register } = useAuth();

  const HandleSubmit = async (e) => {
    e.preventDefault();
    if (await register(email, password, confirmPassword)) {
      navigate("/login");
    }
  };

  return (
    <>
      <div className="login-form">
        <h1>REGISTER</h1>
        <form onSubmit={HandleSubmit}>
          <div className="form-group">
            <label htmlFor="email">EMAIL</label>
            <input
              type="email"
              value={email}
              onChange={(e) => {
                setemail(e.target.value);
              }}
            />
          </div>
          <div className="form-group">
            <label htmlFor="password">PASSWORD</label>
            <input
              type="password"
              value={password}
              onChange={(e) => {
                setPassword(e.target.value);
              }}
            />
          </div>
          <div className="form-group">
            <label htmlFor="confirm-password">CONFIRM</label>
            <input
              type="password"
              value={confirmPassword}
              onChange={(e) => {
                setConfirmPassword(e.target.value);
              }}
            />
          </div>
          <button>REGISTER</button>
        </form>
        <Link to="/login">
          <span>Already have an account?</span>
        </Link>
      </div>
    </>
  );
}

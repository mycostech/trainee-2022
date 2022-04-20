import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";

export default function LoginForm() {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const { login } = useAuth();

  const HandleSubmit = async (e) => {
    e.preventDefault();
    if (await login(email, password)) {
      navigate("/member");
    }
  };
  return (
    <>
      <div className="login-form">
        <h1>LOGIN</h1>
        <form onSubmit={HandleSubmit}>
          <div className="form-group">
            <label htmlFor="email">EMAIL</label>
            <input
              type="email"
              value={email}
              onChange={(e) => {
                setEmail(e.target.value);
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
          <button onClick={HandleSubmit}>LOGIN</button>
        </form>
        <Link to="/register">
          <span>Don't have an account?</span>
        </Link>
      </div>
    </>
  );
}

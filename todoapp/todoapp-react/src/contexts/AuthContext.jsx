import { createContext, useContext, useEffect, useState, useMemo } from "react";
import { axiosHelper } from "../helpers/axiosHelper";
import toast from "react-hot-toast";
import { toastHelper } from "../helpers/toastHelper";

const AuthContext = createContext();

export function useAuth() {
  return useContext(AuthContext);
}

export function AuthProvider({ children }) {
  const [currentUser, setCurrentUser] = useState();
  useEffect(() => {
    async function fetchData() {
      if (!currentUser) {
        const token = localStorage.getItem("token");
        if (token) {
          const response = await axiosHelper.get("/api/auth/getuser");
          if (response.data.success) {
            setCurrentUser(response.data.user);
          }
        } else {
          setCurrentUser(null);
        }
      }
    }
    fetchData();
  }, [currentUser]);

  async function login(email, password) {
    const response = await axiosHelper.post("/api/auth/login", {
      email,
      password,
    });
    if (response.status !== 200) {
      if (response.data.errors) toastHelper.toastJson(response.data.errors, "error");
      if (response.data.message) toast.error(response.data.message);
      return false;
    }
    toast.success("Login Successful");
    setCurrentUser(response.data.user);
    localStorage.setItem("token", response.data.token);
    return true;
  }
  async function register(email, password, confirmPassword) {
    const response = await axiosHelper.post("/api/auth/register", {
      email,
      password,
      confirmPassword,
    });
    if (response.status !== 200) {
      if (response.data.errors) toastHelper.toastJson(response.data.errors, "error");
      if (response.data.message) toast.error(response.data.message);
      return false;
    }
    toast.success("Register Successful");
    return true;
  }

  async function logout() {
    setCurrentUser(null);
    localStorage.removeItem("token");
    toast.success("Logout Successful");
  }
  const value = {
    currentUser,
    login,
    register,
    logout,
  };

  const contextValue = useMemo(() => value, [value]);

  return <AuthContext.Provider value={contextValue}>{children}</AuthContext.Provider>;
}

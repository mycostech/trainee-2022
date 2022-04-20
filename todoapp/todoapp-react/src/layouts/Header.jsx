import React, { useContext, useState } from "react";
import { FaBars } from "react-icons/fa";
import { IoPersonCircleOutline } from "react-icons/io5";
import { BsChevronDown } from "react-icons/bs";
import { SidebarToggle } from "../contexts/SidebarContext";
import { Link } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";

export default function Header() {
  const { sidebarToggle, setSidebarToggle } = useContext(SidebarToggle);
  const [userAccountToggle, setUserAccountToggle] = useState(false);
  const { logout } = useAuth();
  return (
    <div className="header">
      <div
        className="sidebar-button"
        onClick={() => {
          setSidebarToggle(!sidebarToggle);
        }}
      >
        <FaBars />
      </div>
      <div className="logo">
        <Link to="/member">TODO</Link>
      </div>
      <div className="space"></div>
      <div
        className="user-account-button"
        onClick={() => {
          setUserAccountToggle(!userAccountToggle);
        }}
      >
        <IoPersonCircleOutline />
        <div className="dropdown-arrow">
          <BsChevronDown />
        </div>
        {userAccountToggle && (
          <div className="user-account-dropdown">
            <Link to="/" onClick={() => logout()}>
              Logout
            </Link>
          </div>
        )}
      </div>
    </div>
  );
}

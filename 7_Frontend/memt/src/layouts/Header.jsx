import React, { useContext } from "react";
import { FaBars } from "react-icons/fa";
import { IoPersonCircleOutline } from "react-icons/io5";
import { BsChevronDown } from "react-icons/bs";
import { SidebarToggle } from "../contexts/SidebarContext";
import { Link } from "react-router-dom";

export default function Header() {
  const { sidebarToggle, setSidebarToggle } = useContext(SidebarToggle);
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
        <Link to="/">MEMT</Link>
      </div>
      <div className="space"></div>
      <div className="user-account-button">
        <IoPersonCircleOutline />
        <div className="dropdown-arrow">
          <BsChevronDown />
        </div>
      </div>
    </div>
  );
}

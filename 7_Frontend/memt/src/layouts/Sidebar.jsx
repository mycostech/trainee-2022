import React, { useContext } from "react";
import { SidebarToggle } from "../contexts/SidebarContext";
import { AiFillHome, AiFillBell, AiFillSetting } from "react-icons/ai";
import { IoIosStats } from "react-icons/io";
import { GoPencil } from "react-icons/go";

export default function Sidebar() {
  const { sidebarToggle, setSidebarToggle } = useContext(SidebarToggle);

  if (!sidebarToggle) return <></>;
  return (
    <div className="sidebar">
      <div className="sidebar-header"></div>
      <div className="sidebar-body">
        <ul className="sidebar-body-menu">
          <li className="sidebar-body-menu-list">
            <AiFillHome />
            Home
          </li>
          <li className="sidebar-body-menu-list">
            <IoIosStats />
            Report
          </li>
          <li className="sidebar-body-menu-list">
            <GoPencil />
            Profile
          </li>
          <li className="sidebar-body-menu-list">
            <AiFillBell />
            Notification
          </li>
          <li className="sidebar-body-menu-list">
            <AiFillSetting />
            Setting
          </li>
        </ul>
      </div>
    </div>
  );
}

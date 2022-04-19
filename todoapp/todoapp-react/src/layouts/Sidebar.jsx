import React, { useContext } from "react";
import { SidebarToggle } from "../contexts/SidebarContext";
import { AiFillHome, AiFillBell, AiFillSetting } from "react-icons/ai";
import { IoIosStats } from "react-icons/io";
import { GoPencil } from "react-icons/go";
import ClickOutside from "../hooks/useClickOutside";

export default function Sidebar() {
  const { sidebarToggle, setSidebarToggle } = useContext(SidebarToggle);

  return (
    <ClickOutside onClickOutside={() => setSidebarToggle(false)}>
      <div className={sidebarToggle ? "sidebar sidebar-active" : "sidebar sidebar-inactive"}>
        <div
          className="sidebar-header"
          onClick={() => {
            setSidebarToggle(false);
          }}
        >
          &#10006;
        </div>
        <div className="sidebar-body">
          <ul className="sidebar-body-menu">
            <li className="sidebar-body-menu-list">
              <AiFillHome />
              Home
            </li>
            <li className="sidebar-body-menu-list">
              <IoIosStats />
              Statistics
            </li>
            <li className="sidebar-body-menu-list">
              <GoPencil />
              Profile
            </li>
            <li className="sidebar-body-menu-list">
              <AiFillBell />
              Notifications
            </li>
            <li className="sidebar-body-menu-list">
              <AiFillSetting />
              Settings
            </li>
          </ul>
        </div>
      </div>
    </ClickOutside>
  );
}

import React, { useState, useMemo, useEffect } from "react";
import Footer from "./Footer";
import Header from "./Header";
import Sidebar from "./Sidebar";
import { SidebarToggle } from "../contexts/SidebarContext";
import { Outlet } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import { Navigate } from "react-router-dom";

export default function MainPageLayout() {
  const [sidebarToggle, setSidebarToggle] = useState(false);
  const sidebarToggleValue = useMemo(() => ({ sidebarToggle, setSidebarToggle }), [sidebarToggle, setSidebarToggle]);

  const { currentUser } = useAuth();

  if (currentUser === null) {
    return <Navigate to="/login" />;
  }

  return (
    <>
      <SidebarToggle.Provider value={sidebarToggleValue}>
        <Header />
        <Sidebar />
        <Footer />
        <Outlet />
      </SidebarToggle.Provider>
    </>
  );
}

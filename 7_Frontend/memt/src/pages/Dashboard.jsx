import React from "react";
import Header from "../layouts/Header";
import Footer from "../layouts/Footer";
import Sidebar from "../layouts/Sidebar";
import ProfileTab from "../components/ProfileTab";

export default function Dashboard() {
  return (
    <>
      <Header />
      <Sidebar />
      <ProfileTab />
      <div className="dashboard"></div>
      <Footer />
    </>
  );
}

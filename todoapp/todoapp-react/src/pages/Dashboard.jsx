import React from "react";
import Header from "../layouts/Header";
import Footer from "../layouts/Footer";
import Sidebar from "../layouts/Sidebar";

export default function Dashboard() {
  return (
    <>
      <Header />
      <Sidebar />
      <div className="dashboard"></div>
      <Footer />
    </>
  );
}

import { useState, useContext, useMemo } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Dashboard from "./pages/Dashboard";
import { SidebarToggle } from "./contexts/SidebarContext";
import Landing from "./pages/Landing";

function App() {
  const [sidebarToggle, setSidebarToggle] = useState(false);
  const sidebarToggleValue = useMemo(() => ({ sidebarToggle, setSidebarToggle }), [sidebarToggle, setSidebarToggle]);

  return (
    <SidebarToggle.Provider value={sidebarToggleValue}>
      <Router>
        <Routes>
          <Route path="/" element={<Landing />} />
          <Route exact path="/member" element={<Dashboard />} />
        </Routes>
      </Router>
    </SidebarToggle.Provider>
  );
}

export default App;

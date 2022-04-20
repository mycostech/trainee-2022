import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainPageLayout from "./layouts/MainPageLayout";
import Dashboard from "./pages/Dashboard";
import Landing from "./pages/Landing";
import Login from "./pages/Login";
import PageNotFound404 from "./pages/PageNotFound404";
import Register from "./pages/Register";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Landing />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route exact path="/member" element={<MainPageLayout />}>
          <Route index element={<Dashboard />} />
        </Route>
        <Route path="*" element={<PageNotFound404 />} />
      </Routes>
    </Router>
  );
}

export default App;

import React from "react";
import Coach from "./pages/Coach/Coach";
import ErrorPage from "./pages/ErrorPage/ErrorPage";
import NavBar from "./components/NavBar/NavBar";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Test from "./pages/Coach/Test";
import Standings from "./pages/Standings/Standings";
import Footer from "./components/Footer/Footer";

function App() {
  return (
    <Router>
      <NavBar></NavBar>
      <Routes>
        <Route path="/" element={<Test />} />
        <Route path="/coach" element={<Coach />} />
        <Route path="/standings" element={<Standings />} />
        <Route path="*" element={<ErrorPage />} />
      </Routes>
      <Footer></Footer>
    </Router>
  );
}

export default App;

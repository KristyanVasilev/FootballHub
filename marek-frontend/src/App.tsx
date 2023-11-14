import React from "react";
import Coach from "./pages/Coach/Coach";
import NavBar from "./components/NavBar/NavBar";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Test from "./pages/Coach/Test";
import Standings from "./pages/Standings/Standings";
import Footer from "./components/Footer/Footer";
import PageNotFound from "./components/PageNotFound/PageNotFound";
import Fixtures from "./pages/Fixtures/Fixtures";
import Chat from "./pages/Chat/Chat";
import MyForm from "./pages/Chat/MyForm";

function App() {
  return (
    <Router>
      <NavBar></NavBar>
      <Routes>
        <Route path="/" element={<Test />} />
        <Route path="/coach" element={<Coach />} />
        <Route path="/standings" element={<Standings />} />
        <Route path="/fixtures" element={<Fixtures />} />
        <Route path="/players" element={<MyForm />} />
        <Route path="*" element={<PageNotFound />} />
      </Routes>
      <Footer></Footer>
    </Router>
  );
}

export default App;

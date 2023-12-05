import { useEffect } from "react";
import Coach from "./pages/Coach/Coach";
import NavBar from "./components/NavBar/NavBar";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Test from "./pages/Coach/Test";
import Standings from "./pages/Standings/Standings";
import Footer from "./components/Footer/Footer";
import PageNotFound from "./components/PageNotFound/PageNotFound";
import Fixtures from "./pages/Fixtures/Fixtures";
import AllPlayers from "./pages/Team/AllPlayers";
import { gapi } from "gapi-script";
import { AuthProvider } from "./Context/AuthContext";
import Login from "./components/Auth/Login";
function App() {
  useEffect(() => {
    function start() {
      gapi.client.init({
        clientId: process.env.REACT_APP_GOOGLE_CLIENT_ID,
        scope: "",
      });
    }

    gapi.load("client:auth2", start);
  });

  return (
    //var accesToken = gapi.auth.getToken().acces_token;
    <AuthProvider>
      <Router>
        <NavBar />
        <Login />
        <Routes>
          <Route path="/" element={<Test />} />
          <Route path="/coach" element={<Coach />} />
          <Route path="/standings" element={<Standings />} />
          <Route path="/fixtures" element={<Fixtures />} />
          <Route path="/team" element={<AllPlayers />} />
          <Route path="*" element={<PageNotFound />} />
        </Routes>
        <Footer></Footer>
      </Router>
    </AuthProvider>
  );
}

export default App;

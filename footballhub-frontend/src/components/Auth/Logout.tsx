import React from "react";
import { GoogleLogout } from "react-google-login";
import { useAuth } from "../../Context/AuthContext";

const Logout = () => {
  const clientId = process.env.REACT_APP_GOOGLE_CLIENT_ID;
  const { setUser } = useAuth();

  const onSuccess = () => {
    console.log("LOGOUT SUCCESS!");
    setUser(null);
  };

  return (
    <div>
      <GoogleLogout
        clientId={clientId as string}
        buttonText="Logout"
        onLogoutSuccess={onSuccess}
      />
    </div>
  );
};

export default Logout;

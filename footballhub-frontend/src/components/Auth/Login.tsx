import React from "react";
import { GoogleLogin, GoogleLoginResponse } from "react-google-login";
import { useAuth } from "../../Context/AuthContext";

const Login = () => {
  const clientId = process.env.REACT_APP_GOOGLE_CLIENT_ID;
  const { setUser } = useAuth();

  const onSuccess = (res: any) => {
    console.log("LOGIN SUCCESS!");

    setUser(res.profileObj);
  };

  const onFailure = (res: GoogleLoginResponse) => {
    console.log("LOGIN FAILED!");
  };

  return (
    <div>
      <GoogleLogin
        clientId={clientId as string}
        buttonText="Login"
        onSuccess={onSuccess}
        onFailure={onFailure}
        cookiePolicy={"single_host_origin"}
        isSignedIn={true}
      />
    </div>
  );
};

export default Login;

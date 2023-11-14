import { useEffect, useState } from "react";
import { styled } from "@mui/material/styles";
import { Grid, Typography } from "@mui/material";
import axios, { AxiosResponse } from "axios";
import { columns } from "./config";
import { APIResponse } from "./types";
import StandingTable from "./StandingTable";
import { urlStandings } from "../../config/endpoint";

const Img = styled("img")({
  margin: "auto",
  display: "block",
});

const FlagImage = styled("img")({
  margin: "auto",
  display: "block",
  maxWidth: "80px",
  maxHeight: "80px",
  boxShadow: "0px 2px 4px rgba(0, 0, 0, 0.4)",
  borderRadius: "10%",
});

const Standings = () => {
  const [standing, setStanding] = useState<APIResponse>();

  useEffect(() => {
    axios
      .get(urlStandings)
      .then((response: AxiosResponse<APIResponse>) => {
        setStanding(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  return (
    <>
      <Grid container justifyContent="center" paddingTop={5} paddingBottom={5}>
        <Grid item>
          <Img src={standing?.response[0]?.league.logo} />
        </Grid>
        <Grid item margin={5} paddingTop={2}>
          <Typography variant="h4">
            {standing?.response[0]?.league.name} -{" "}
            {standing?.response[0]?.league.season}
          </Typography>
        </Grid>
        <Grid item paddingTop={5}>
          <FlagImage src={standing?.response[0]?.league.flag} />
        </Grid>
      </Grid>
      <StandingTable
        columns={columns}
        standings={standing?.response[0]?.league.standings}
      />
    </>
  );
};

export default Standings;

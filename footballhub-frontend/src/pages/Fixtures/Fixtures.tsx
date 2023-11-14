import {
  Box,
  Paper,
  Table,
  TableContainer,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Typography,
  Grid,
  styled,
} from "@mui/material";
import theme from "../../theme";
import { useEffect, useState } from "react";
import axios, { AxiosResponse } from "axios";
import { APICurrentFixtureResponse, APILatestFixturesResponse } from "./types";
import CurrentFixture from "./CurrentFixture";
import LatestFixtures from "./LatestFixtures";
import { urlCurrentFixture, urlLatestFixtures } from "../../config/endpoint";

const Img = styled("img")({
  display: "flex",
  maxWidth: "40px",
  maxHeight: "40px",
});

const Fixtures = () => {
  const [currentFixture, setCurrentFixture] =
    useState<APICurrentFixtureResponse>();

  const [latestFixture, setLatestFixture] =
    useState<APILatestFixturesResponse[]>();

  const handleTableRowClick = (fixture: APILatestFixturesResponse) => {
    console.log("Clicked fixture:", fixture);
  };

  useEffect(() => {
    axios
      .get(urlCurrentFixture)
      .then((response: AxiosResponse<APICurrentFixtureResponse>) => {
        setCurrentFixture(response.data);
        console.log(response);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get(urlLatestFixtures)
      .then((response: AxiosResponse<APILatestFixturesResponse[]>) => {
        setLatestFixture(response.data);
        console.log(response);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  let formattedDateTime = "";

  if (currentFixture && currentFixture.fixture && currentFixture.fixture.date) {
    const date = new Date(currentFixture.fixture.date);
    const formattedDate = date.toLocaleDateString("en-GB", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
    });
    const formattedTime = date.toLocaleTimeString("en-GB", {
      hour: "2-digit",
      minute: "2-digit",
    });

    formattedDateTime = `${formattedDate} ${formattedTime}`;
  }

  return (
    <Box
      sx={{
        paddingRight: theme.spacing(2),
        paddingLeft: theme.spacing(2),
        marginBottom: theme.spacing(5),
        marginTop: theme.spacing(5),
      }}
    >
      <Typography variant="h4" color="white">
        | FIXTURES & RESULTS
      </Typography>

      <Grid container spacing={2} style={{ paddingTop: 10 }}>
        <Grid item xs={12} sm={12} md={8} lg={8}>
          <CurrentFixture
            currentFixture={currentFixture}
            formattedDateTime={formattedDateTime}
          />
          <Box
            component={Paper}
            elevation={3}
            sx={{
              maxWidth: 1500,
              borderBottomLeftRadius: 20,
              borderBottomRightRadius: 20,
            }}
          >
            <TableContainer
              component={Paper}
              elevation={3}
              sx={{
                maxWidth: 1500,
                borderBottomLeftRadius: 20,
                borderBottomRightRadius: 20,
              }}
            >
              <Table stickyHeader aria-label="customized table">
                <TableHead
                  style={{
                    backgroundColor: theme.palette.primary.main,
                    height: 85,
                    display: "flex",
                    alignItems: "center",
                  }}
                >
                  <TableRow>
                    <Typography
                      align="left"
                      style={{ color: "white", marginLeft: 10 }}
                    >
                      UNCOMING FIXTURES:
                    </Typography>
                  </TableRow>
                </TableHead>
                <TableBody>
                  <TableRow>
                    <TableCell>opa1 opa1opa1opa1opa1opa1 opa1 opa1</TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>opa2</TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>opa3</TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>opa4</TableCell>
                  </TableRow>
                  <TableRow>
                    <TableCell>opa4</TableCell>
                  </TableRow>
                </TableBody>
              </Table>
            </TableContainer>
          </Box>
        </Grid>
        <LatestFixtures
          latestFixture={latestFixture}
          handleTableRowClick={handleTableRowClick}
        />
      </Grid>
    </Box>
  );
};
export default Fixtures;

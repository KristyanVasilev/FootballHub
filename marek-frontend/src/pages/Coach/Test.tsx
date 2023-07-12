import * as React from "react";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { useEffect, useState } from "react";
import axios, { AxiosResponse } from "axios";
import { urlCoach } from "../../endpoint";
import { Coach, CoachState } from "./types";
import {
  Alert,
  AlertTitle,
  Box,
  ButtonBase,
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  CircularProgress,
  Grid,
  Slide,
  Typography,
} from "@mui/material";
import { columns } from "./config";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
    fontWeight: "bold",
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const Img = styled("img")({
  margin: "auto",
  display: "block",
  maxWidth: "80%",
  maxHeight: "75%",
});

const Test = () => {
  const [coach, setCoach] = useState<Coach>();
  const [coachState, setCoachState] = useState<CoachState>("idle");

  useEffect(() => {
    setCoachState("loading");
    axios
      .get(urlCoach)
      .then((response: AxiosResponse<Coach>) => {
        setCoach(response.data);
        setCoachState("success");
      })
      .catch((error) => {
        setCoachState("error");
        console.log(error);
      });
  }, []);
  return (
    <>
      <Paper
        sx={{
          p: 10,
          margin: "auto",
          maxWidth: 1000,
          flexGrow: 1,
          bgcolor: "transperant",
        }}
      >
        <Grid container spacing={2}>
          <Grid item>
            <Img
              alt="complex"
              src="https://cdn.marica.bg/images/marica.bg/82/640_82590.jpeg"
            />
          </Grid>
          <Grid item xs={12} sm container>
            <Grid item xs container direction="column" spacing={2}>
              <Grid item xs>
                <Typography gutterBottom variant="subtitle1" component="div">
                  Name - {coach?.firstName} {coach?.lastName}
                </Typography>
                <Typography variant="body2" gutterBottom>
                  Age - {coach?.age === null ? "No information" : coach?.age}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Nationality - {coach?.nationality}
                </Typography>
              </Grid>
              <Grid item>
                <Typography sx={{ cursor: "pointer" }} variant="body2">
                  Current Team - Marek
                </Typography>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Paper>
      <Slide in direction="up">
        <TableContainer component={Card}>
          <Table
            align="center"
            sx={{
              width: "50%",
              minWidth: 200,
              textAlign: "center",
              bgcolor: "transperant",
            }}
            stickyHeader
            aria-label="customized table"
          >
            <TableHead>
              <StyledTableCell
                colSpan={4}
                sx={{
                  fontSize: "1.5rem",
                  textAlign: "center",
                  backgroundColor: "rgba(30, 81, 123)",
                }}
              >
                Career
              </StyledTableCell>
              <TableRow>
                {columns.map((column, index) => {
                  return (
                    <TableCell
                      key={index}
                      sx={{
                        fontWeight: "bold",
                        backgroundColor: "rgba(217, 30, 24)",
                        color: "white",
                        textAlign: "center",
                      }}
                    >
                      <Box>
                        <Typography>{column.label}</Typography>
                      </Box>
                    </TableCell>
                  );
                })}
              </TableRow>
            </TableHead>
            <TableBody>
              {coach?.career.map((row) => {
                return (
                  <StyledTableRow key={row.team.name}>
                    <StyledTableCell
                      align="center"
                      component="th"
                      scope="row"
                      sx={{ fontSize: "1.2rem" }}
                    >
                      {row.team.name}
                    </StyledTableCell>
                    <StyledTableCell align="center" sx={{ width: 100 }}>
                      <img
                        src={row.team.logo}
                        style={{
                          maxWidth: "50%",
                          maxHeight: "50%",
                          textAlign: "center",
                        }}
                      />
                    </StyledTableCell>
                    <StyledTableCell align="center">
                      {row.start}
                    </StyledTableCell>
                    <StyledTableCell align="center">{row.end}</StyledTableCell>
                  </StyledTableRow>
                );
              })}
              {coachState === "loading" && (
                <TableRow>
                  <TableCell colSpan={6}>
                    <Box>
                      <CircularProgress />
                    </Box>
                  </TableCell>
                </TableRow>
              )}
              {coachState === "error" && (
                <TableRow>
                  <TableCell colSpan={6}>
                    <Alert severity="error">
                      <AlertTitle>Error</AlertTitle>
                      {"Something went wrong..."}
                    </Alert>
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
      </Slide>
    </>
  );
};

export default Test;

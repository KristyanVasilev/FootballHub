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
import { CustomTableProps } from "./types";
import React from "react";
import theme from "../../theme";

const Img = styled("img")({
  margin: "auto",
  display: "block",
  maxWidth: "35px",
  maxHeight: "35px",
});

const StandingTable: React.FC<CustomTableProps> = ({ columns, standings }) => {
  return (
    <Box display="flex" justifyContent="center" sx={{ p: 2 }}>
      <TableContainer
        component={Paper}
        elevation={3}
        sx={{ maxWidth: 1500, borderRadius: 5 }}
      >
        <Table align="center" stickyHeader aria-label="customized table">
          <TableHead>
            <TableRow>
              {columns.map((column, index) => (
                <TableCell
                  key={index}
                  sx={{
                    fontWeight: "bold",
                    backgroundColor: theme.palette.primary.main,
                    color: "white",
                    textAlign: "center",
                  }}
                >
                  <Box>
                    <Typography>{column.label}</Typography>
                  </Box>
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {standings?.map((standingsArray, index) => (
              <React.Fragment key={index}>
                {standingsArray.map((standing, innerIndex) => (
                  <TableRow
                    key={innerIndex}
                    sx={{
                      backgroundColor:
                        standing.team.name === "Marek"
                          ? theme.palette.secondary.light
                          : "inherit",
                    }}
                  >
                    <TableCell
                      sx={{
                        backgroundColor:
                          standing.rank === "1" || standing.rank === "2"
                            ? theme.palette.success.main
                            : parseInt(standing.rank) >
                              standingsArray.length - 4
                            ? theme.palette.primary.main
                            : standing.rank === "3"
                            ? theme.palette.secondary.main
                            : "inherit",
                      }}
                    >
                      {standing.rank}
                    </TableCell>
                    <TableCell>
                      <Grid container>
                        <Grid item>
                          <Img src={standing.team.logo} />
                        </Grid>
                        <Grid item margin={1}>
                          {standing.team.name}
                        </Grid>
                      </Grid>
                    </TableCell>
                    <TableCell>
                      <Typography>{standing.all.played}</Typography>
                    </TableCell>
                    <TableCell>
                      {" "}
                      <Typography>
                        {`${standing.all.goals.for} - ${standing.all.goals.against}`}
                      </Typography>
                    </TableCell>
                    <TableCell>
                      {" "}
                      <Typography>
                        {`W${standing.all.win}/L${standing.all.lose}/D${standing.all.draw}`}
                      </Typography>
                    </TableCell>
                    <TableCell>
                      {" "}
                      <Typography>{standing.points}</Typography>
                    </TableCell>
                    <TableCell>
                      {" "}
                      <Typography>{standing.description}</Typography>
                    </TableCell>
                    <TableCell>
                      {" "}
                      <Typography>
                        {new Date(standing.update).toLocaleDateString("en-GB", {
                          day: "2-digit",
                          month: "2-digit",
                          year: "numeric",
                        })}
                      </Typography>
                    </TableCell>
                  </TableRow>
                ))}
              </React.Fragment>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default StandingTable;

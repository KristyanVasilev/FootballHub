import { useEffect, useState } from "react";
import { PlayerResponseApiModel, PlayerRotoObject } from "./types";
import axios, { AxiosResponse } from "axios";
import { urlTeam } from "../../config/endpoint";
import TableContainer from "@mui/material/TableContainer/TableContainer";
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@mui/material";

const Team = () => {
  const [team, setTeam] = useState<PlayerRotoObject>();

  useEffect(() => {
    axios
      .get(urlTeam)
      .then((response: AxiosResponse<PlayerRotoObject>) => {
        setTeam(response.data);
        console.log(response.data);
        console.log(team?.response, "team");
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  console.log(team?.response, "team1");

  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Player Name</TableCell>
            <TableCell>Team</TableCell>
            <TableCell>League</TableCell>
            <TableCell>Goals</TableCell>
            <TableCell>Cards</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {team?.response?.map((playerResponse: PlayerResponseApiModel) => {
            if (!playerResponse) {
              console.log("Invalid player response");
              return null;
            }

            return (
              <TableRow key={playerResponse?.player?.id}>
                <TableCell>{playerResponse.player.name}</TableCell>
                <TableCell>{playerResponse.player.age}</TableCell>
                <TableCell>{playerResponse.player.birth.date}</TableCell>
                <TableCell>{playerResponse.player.nationality}</TableCell>
              </TableRow>
            );
          })}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default Team;

import * as React from "react";
import Card from "@mui/material/Card";
import CardMedia from "@mui/material/CardMedia";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { styled, ThemeProvider } from "@mui/material/styles";
import { Player } from "./types";
import axios, { AxiosResponse } from "axios";
import { urlAllPlayers } from "../../config/endpoint";
import { useEffect } from "react";
import PlayerModal from "./PlayerModal";
import theme from "../../theme";
import { useAuth } from "../../Context/AuthContext";
// TODO remove, this demo shouldn't need to reset the theme.

const ShakeCard = styled(Card)({
  transition: "transform 0.2s ease-out",
  borderRadius: "5%",
  background: "rgba(0, 0, 0, 0.5)",
  "&:hover": {
    transform: "scale(1.05)",
  },
});
const TextOverlay = styled("div")({
  position: "absolute",
  bottom: 0,
  left: 0,
  width: "100%",
  background: "rgba(0, 0, 0, 0.5)",
  padding: "1rem",
  color: "white",
});

export default function AllPlayers() {
  const [players, setPlayers] = React.useState<Player[]>();
  const [selectedPlayer, setSelectedPlayer] = React.useState<Player | null>(
    null
  );

  const handleCardClick = (playerId: number) => {
    const clickedPlayer = players?.find((player) => player.id === playerId);
    setSelectedPlayer(clickedPlayer || null);
  };
  const handleCloseModal = () => {
    setSelectedPlayer(null);
  };
  useEffect(() => {
    axios
      .get(urlAllPlayers)
      .then((response: AxiosResponse<Player[]>) => {
        setPlayers(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  const { user } = useAuth();
  console.log(user, "user");
  return (
    <ThemeProvider theme={theme}>
      <Container sx={{ py: 8 }} maxWidth="lg">
        <Grid container spacing={4}>
          {players?.map((player) => (
            <Grid item key={player.id} xs={12} sm={6} md={3}>
              <ShakeCard
                sx={{
                  height: "100%",
                  width: "100%",
                  display: "flex",
                  flexDirection: "column",
                  position: "relative",
                }}
                onClick={() => handleCardClick(player.id)}
              >
                <CardMedia
                  component="div"
                  sx={{
                    height: "100%",
                    width: "100%",
                    position: "relative",
                    "& img": {
                      objectFit: "cover",
                      width: "100%",
                      height: "100%",
                    },
                  }}
                >
                  <img
                    src={player.photo}
                    alt={`Card background for ${player.name}`}
                  />
                  <TextOverlay>
                    <Typography variant="h4" fontWeight="bold">
                      {player.name}
                    </Typography>
                  </TextOverlay>
                </CardMedia>
              </ShakeCard>
            </Grid>
          ))}
        </Grid>
        {selectedPlayer && (
          <PlayerModal player={selectedPlayer} onClose={handleCloseModal} />
        )}
      </Container>
    </ThemeProvider>
  );
}

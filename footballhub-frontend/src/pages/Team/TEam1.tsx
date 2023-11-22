import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Button from "@mui/material/Button";
import CameraIcon from "@mui/icons-material/PhotoCamera";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import CssBaseline from "@mui/material/CssBaseline";
import Grid from "@mui/material/Grid";
import Stack from "@mui/material/Stack";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import Link from "@mui/material/Link";
import {
  createTheme,
  makeStyles,
  styled,
  ThemeProvider,
} from "@mui/material/styles";
import { useNavigate } from "react-router-dom";

const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// TODO remove, this demo shouldn't need to reset the theme.
const defaultTheme = createTheme();

const ShakeCard = styled(Card)({
  transition: "transform 0.2s ease-out",
  borderRadius: "5%",
  background: "rgba(0, 0, 0, 0.5)",
  "&:hover": {
    transform: "scale(1.05)", // Adjust the translation for the shake effect
  },
});
const TextOverlay = styled("div")({
  position: "absolute",
  bottom: 0,
  left: 0,
  width: "100%",
  background: "rgba(0, 0, 0, 0.5)", // Dark background with 50% opacity
  padding: "1rem",
  color: "white",
});

export default function Album() {
  const navigate = useNavigate(); // Use useNavigate hook for navigation

  const handleCardClick = () => {
    navigate("/coach");
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container sx={{ py: 8 }} maxWidth="lg">
        <Grid container spacing={4}>
          {cards.map((card) => (
            <Grid item key={card} xs={12} sm={6} md={3}>
              <ShakeCard
                sx={{
                  height: "100%",
                  width: "100%",
                  display: "flex",
                  flexDirection: "column",
                  position: "relative",
                }}
                onClick={handleCardClick}
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
                    src="https://marek1915.com/wp-content/uploads/2023/07/plamen-mladenov-removebg-preview.png"
                    alt="Card background"
                  />
                  <TextOverlay>
                    <Typography variant="h4" fontWeight="bold">
                      Name
                    </Typography>
                    <Typography variant="h6" fontWeight="bold">
                      Position
                    </Typography>
                  </TextOverlay>
                </CardMedia>
              </ShakeCard>
            </Grid>
          ))}
        </Grid>
      </Container>
    </ThemeProvider>
  );
}

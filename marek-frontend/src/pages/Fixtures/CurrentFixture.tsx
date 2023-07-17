import React from "react";
import { Box, Grid, Paper, Typography, styled } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import { CurrentFixtureProps } from "./types";

const Img = styled("img")({
  margin: "auto",
  display: "block",
  maxWidth: "80px",
  maxHeight: "80px",
});

const CurrentFixture: React.FC<CurrentFixtureProps> = ({
  currentFixture,
  formattedDateTime,
}) => {
  const theme = useTheme();

  return (
    <Box
      component={Paper}
      elevation={3}
      sx={{
        maxWidth: 1500,
        borderTopLeftRadius: 10,
        borderTopRightRadius: 10,
        backgroundImage:
          "url(https://w7.pngwing.com/pngs/205/83/png-transparent-pro-evolution-soccer-2016-pro-evolution-soccer-2015-xbox-360-video-game-american-football-miscellaneous-atmosphere-landscape.png)",
        backgroundSize: "cover",
        backgroundPosition: "center bottom",
        minHeight: 300,
        display: "flex",
        flexDirection: "column",
        textAlign: "center",
        alignItems: "center",
        justifyContent: "center",
        paddingLeft: 10,
      }}
    >
      <Grid container>
        <Grid
          item
          container
          justifyContent="space-evenly"
          alignItems="flex-end"
        >
          <Grid item>
            <Img src={currentFixture?.teams.home.logo} />
            <Typography
              variant="h5"
              sx={{
                fontFamily: "fantasy",
                color: "white",
                textShadow: `0 0 2px black`,
              }}
            >
              {currentFixture?.teams.home.name}
            </Typography>
          </Grid>
          <Grid item>
            <Typography
              variant="h5"
              sx={{
                fontFamily: "fantasy",
                color: "white",
                textShadow: `0 0 2px black`,
              }}
            >
              vs
            </Typography>
          </Grid>
          <Grid item>
            <Img src={currentFixture?.teams.away.logo} />
            <Typography
              variant="h5"
              sx={{
                fontFamily: "fantasy",
                color: "white",
                textShadow: `0 0 2px black`,
              }}
            >
              {currentFixture?.teams.away.name}
            </Typography>
          </Grid>
        </Grid>
        <Grid item xs={12} paddingTop={4}>
          <Typography
            variant="h5"
            sx={{
              fontFamily: "fantasy",
              color: "white",
              textShadow: `0 0 2px black`,
            }}
          >
            {currentFixture?.fixture.venue.name},{" "}
            {currentFixture?.fixture.venue.city}
          </Typography>
          <Typography
            variant="h5"
            sx={{
              fontFamily: "fantasy",
              color: "white",
              textShadow: `0 0 2px black`,
            }}
          >
            {formattedDateTime}
          </Typography>
        </Grid>
      </Grid>
    </Box>
  );
};

export default CurrentFixture;

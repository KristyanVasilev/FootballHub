import { Box, Container, Paper, Typography } from "@mui/material";
import React from "react";
import SentimentVeryDissatisfiedIcon from "@mui/icons-material/SentimentVeryDissatisfied";
import theme from "../../theme";

const PageNotFound = () => {
  return (
    <Container
      style={{
        marginTop: theme.spacing(7.5),
        marginBottom: theme.spacing(48),
      }}
    >
      <Paper
        elevation={2}
        style={{
          backgroundColor: theme.palette.secondary.light,
          display: "flex",
          flexDirection: "row",
          justifyContent: "center",
        }}
      >
        <SentimentVeryDissatisfiedIcon
          style={{
            height: theme.spacing(10),
            width: theme.spacing(10),
            marginRight: theme.spacing(10),
            marginTop: theme.spacing(1),
          }}
        />
        <Box component="span">
          <Typography variant="h3">Page not found</Typography>
          <Typography variant="h5">
            We're sorry, we couldn't find the page you requested
          </Typography>
        </Box>
      </Paper>
    </Container>
  );
};

export default PageNotFound;

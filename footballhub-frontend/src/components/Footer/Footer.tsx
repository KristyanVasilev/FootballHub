import Box from "@mui/material/Box";
import { Container, Grid, Link, Typography } from "@mui/material";
import FacebookIcon from "@mui/icons-material/Facebook";
import YouTubeIcon from "@mui/icons-material/YouTube";
import InstagramIcon from "@mui/icons-material/Instagram";
import theme from "../../theme";
import { MAREK_MEDIA_URLS } from "../../config/constants";

const Footer = () => {
  return (
    <footer
      style={{
        backgroundColor: theme.palette.secondary.main,
        padding: "20px 0",
      }}
    >
      <Box px={{ xs: 3, sm: 3 }} py={{ xs: 3, sm: 3 }}>
        <Container maxWidth="lg">
          <Box textAlign="center" pb={{ xs: 3, sm: 2 }}>
            <Grid container spacing={2} justifyContent="center">
              <Grid item>
                <Link
                  href={MAREK_MEDIA_URLS.facebook}
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  <FacebookIcon
                    style={{ fontSize: 30, marginRight: 10, color: "white" }}
                  />
                </Link>
              </Grid>
              <Grid item>
                <Link
                  href={MAREK_MEDIA_URLS.youtube}
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  <YouTubeIcon
                    style={{ fontSize: 30, marginRight: 10, color: "white" }}
                  />
                </Link>
              </Grid>
              <Grid item>
                <Link
                  href={MAREK_MEDIA_URLS.instagram}
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  <InstagramIcon style={{ fontSize: 30, color: "white" }} />
                </Link>
              </Grid>
            </Grid>
          </Box>
          <Box textAlign="center" pb={{ xs: 3, sm: 2 }}>
            <Typography variant="body1" color="white" fontSize={18}>
              Copyright © {new Date().getFullYear()} Marek FC. All rights
              reserved. Welcome to the official website of Marek FC, your source
              for the latest news, updates, and exclusive content.
            </Typography>
          </Box>
        </Container>
      </Box>
    </footer>
  );
};
export default Footer;

import { createTheme, responsiveFontSizes } from "@mui/material";

const theme = createTheme({
  palette: {
    primary: {
      main: "rgba(217, 30, 24)",
    },
    secondary: {
      main: "rgba(30, 81, 123)",
      light: "#B0C4DE",
    },
    background: {
      default: "#F7EAEA",
    },
    success: {
      main: "#03C03C",
    },
  },
  typography: {
    h4: {
      fontFamily: "fantasy",
    },
    body1: {
      fontWeight: "bold",
    },
  },
  components: {
    MuiAppBar: {
      styleOverrides: {
        root: {
          zIndex: 1201,
          backgroundColor: "rgba(217, 30, 24)",
          position: "sticky",
        },
      },
    },
    MuiTableBody: {
      styleOverrides: {
        root: {
          backgroundColor: "rgba(244, 239, 239)",
          padding: 2,
          fontWeight: "bold",
          color: "black",
          textAlign: "center",
        },
      },
    },
    MuiTableCell: {
      styleOverrides: {
        body: {
          fontWeight: "bold",
          color: "black",
          textAlign: "center",
        },
      },
    },
  },
});

export default responsiveFontSizes(theme);

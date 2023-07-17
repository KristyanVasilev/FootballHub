import {
  Box,
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  Typography,
  styled,
} from "@mui/material";
import { LatestFixturesProps } from "./types";
import { useTheme } from "@mui/material/styles";

const Img = styled("img")({
  display: "flex",
  maxWidth: "40px",
  maxHeight: "40px",
});

const LatestResultsComponent: React.FC<LatestFixturesProps> = ({
  latestFixture,
  handleTableRowClick,
}) => {
  const theme = useTheme();
  return (
    <Grid item xs={12} sm={12} md={4} lg={4}>
      <Box
        sx={{
          borderTopLeftRadius: 10,
          borderTopRightRadius: 10,
          backgroundColor: theme.palette.primary.main,
          display: "flex",
          minHeight: "70px",
          textAlign: "left",
          alignItems: "center",
        }}
      >
        <Typography
          variant="h5"
          style={{ color: "white", marginLeft: 10, fontFamily: "fantasy" }}
        >
          LATEST RESULTS:
        </Typography>
      </Box>
      <TableContainer
        component={Paper}
        elevation={3}
        sx={{
          borderBottomLeftRadius: 20,
          borderBottomRightRadius: 20,
          maxHeight: "580px",
        }}
      >
        <Table>
          <TableBody>
            {latestFixture
              ?.sort(
                (b, a) =>
                  new Date(a.fixture.date).getTime() -
                  new Date(b.fixture.date).getTime()
              )
              .map((fixture, index) => (
                <TableRow
                  key={index}
                  onClick={() => handleTableRowClick(fixture)}
                >
                  <TableCell>
                    <Grid
                      container
                      alignItems="center"
                      textAlign="center"
                      justifyContent="center"
                      spacing={5}
                    >
                      <Grid item>
                        <Typography variant="body2">
                          {fixture.teams.home.name}
                        </Typography>
                      </Grid>
                      <Grid item>
                        <Img src={fixture.teams.home.logo} />
                      </Grid>
                      <Grid item>
                        <Typography variant="body2">
                          {`${fixture.goals.home} - ${fixture.goals.away}`}
                        </Typography>
                      </Grid>
                      <Grid item>
                        <Img src={fixture.teams.away.logo} />
                      </Grid>
                      <Grid item>
                        <Typography variant="body2">
                          {fixture.teams.away.name}
                        </Typography>
                      </Grid>
                      <Grid item xs={12}>
                        <Typography
                          variant="body2"
                          align="center"
                          style={{ marginLeft: "5px" }}
                        >
                          {`${fixture.fixture.venue.name}, ${
                            fixture.fixture.venue.city
                          }, ${new Date(
                            fixture.fixture.date
                          ).toLocaleDateString()} ${new Date(
                            fixture.fixture.date
                          ).toLocaleTimeString("en-GB", {
                            hour: "2-digit",
                            minute: "2-digit",
                          })}`}
                        </Typography>
                      </Grid>
                    </Grid>
                  </TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  );
};

export default LatestResultsComponent;

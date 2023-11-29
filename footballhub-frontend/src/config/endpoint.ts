const baseURL = process.env.REACT_APP_API_URL;
export const urlCoach = `${baseURL}/Coach/GetCoachInfo`;
export const urlStandings = `${baseURL}/Standings/GetStandingsInfo`;
export const urlLatestFixtures = `${baseURL}/Coach/GetftInfo`;
export const urlAllPlayers = `${baseURL}/Team/GetAllPlayers`;
//localhost:7043/Fixture/GetLatestFixturesInfo
export const urlCurrentFixture = `${baseURL}/Coach/GetNExtInfo`;

export interface CurrentFixture {
  id: string;
  date: string;
  venue: {
    name: string;
    city: string;
  };
}

export interface CurrentFixtureTeam {
  name: string;
  logo: string;
}

export interface APICurrentFixtureResponse {
  fixture: CurrentFixture;
  teams: {
    home: CurrentFixtureTeam;
    away: CurrentFixtureTeam;
  };
}

export interface CurrentFixtureProps {
  currentFixture: APICurrentFixtureResponse | undefined;
  formattedDateTime: string;
}

export interface LatestFixtures {
  id: string;
  referee: string | null;
  timezone: string;
  date: string;
  timestamp: number;
  periods: {
    first: string;
    second: string;
  };
  venue: {
    id: string | null;
    name: string;
    city: string;
  };
  status: {
    long: string;
    short: string;
    elapsed: string;
  };
}

export interface LatestFixturesTeam {
  id: string;
  name: string;
  logo: string;
  winner: string;
}

export interface Goal {
  home: string;
  away: string;
}

export interface APILatestFixturesResponse {
  fixture: LatestFixtures;
  teams: {
    home: LatestFixturesTeam;
    away: LatestFixturesTeam;
  };
  goals: Goal;
}

export interface LatestFixturesProps {
  latestFixture: APILatestFixturesResponse[] | undefined;
  handleTableRowClick: (fixture: APILatestFixturesResponse) => void;
}

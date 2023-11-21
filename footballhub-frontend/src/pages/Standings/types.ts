export interface TableColumn {
  label: string;
}

export interface Team {
  name: string;
  logo: string;
}

export interface Goals {
  for: string;
  against: string;
}

export interface TeamStats {
  played: string;
  win: string;
  draw: string;
  lose: string;
  goals: Goals;
}

export interface Standing {
  rank: number;
  team: Team;
  points: string;
  goalsDiff: string;
  status: string;
  description: string | null;
  all: TeamStats;
  update: string;
}

export interface League {
  name: string;
  logo: string;
  flag: string;
  season: number;
  standings: Standing[][];
}

export interface Response {
  league: League;
}

export interface APIResponse {
  response: Response[];
}

export interface CustomTableProps {
  columns: TableColumn[];
  standings: Standing[][] | undefined;
}

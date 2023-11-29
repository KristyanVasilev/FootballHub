export interface PlayerRotoObject {
  response: PlayerResponseApiModel[];
}

export interface PlayerResponseApiModel {
  player: PlayerApiModel;
  statistics: PlayerStatisticsApiModel[];
}

export interface PlayerStatisticsApiModel {
  team: PlayerTeamApiModel;
  league: string;
  goals: string;
  cards: string;
}

export interface PlayerApiModel {
  id: number;
  name: string;
  firstName: string;
  lastname: string;
  age: number | null;
  birth: PlayerBirthApiModel;
  nationality: string;
  photo: string;
  injured: boolean;
}

export interface PlayerBirthApiModel {
  date: string;
}

export interface PlayerTeamApiModel {
  id: number;
  name: string;
  logo: string;
}

export interface PlayerLeagueApiModel {
  id: number;
  name: string;
  country: string;
  logo: string;
  flag: string;
  season: number;
}
export interface PlayerGamesApiModel {
  appearences: number | null;
  lineups: number | null;
  minutes: number | null;
  position: string;
  captain: boolean;
}

export interface PlayerGoalsApiModel {
  total: number | null;
}

export interface PlayerCardsApiModel {
  yellow: number | null;
  yellowRed: number | null;
  red: number | null;
}

export interface Player {
  id: number;
  name: string;
  photo: string;
}

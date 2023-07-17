export type CoachState = "success" | "error" | "loading" | "idle";

export interface Coach {
  firstName: string;
  lastName: string;
  age: number | null;
  photoUrl: string;
  nationality: string;
  career: Career[];
}

export interface Team {
  id: number;
  name: string;
  logo: string;
}

export interface Career {
  team: Team;
  start: string;
  end: string | null;
}

export interface TableColumn {
  label: string;
}

export interface CurrentGameProps {
  label: string;
}

import React, { useEffect, useState } from "react";
import axios, { AxiosResponse } from "axios";
import { urlCoach } from "../../endpoint";

interface Coach {
  firstName: string;
  lastName: string;
  age: number | null;
  photoUrl: string;
  nationality: string;
  career: Career[];
}

interface Team {
  id: number;
  name: string;
  logo: string;
}

interface Career {
  team: Team;
  start: string;
  end: string | null;
}

const CoachInfo = () => {
  const [coach, setCoach] = useState<Coach>();

  useEffect(() => {
    axios.get(urlCoach).then((response: AxiosResponse<Coach>) => {
      setCoach(response.data);
      console.log(response.data);
    });
  }, []);

  return (
    <div>
      <header>
        {coach && (
          <div>
            <h1>Coach Information</h1>
            <p>
              Name: {coach.firstName} {coach.lastName}
            </p>
            <p>Age: {coach.age}</p>
            <p>Nationality: {coach.nationality}</p>
            <img src={coach.photoUrl} alt="Coach" />
            <h2>Career</h2>
            <ul>
              {coach.career.map((careerData, index) => (
                <li key={index}>
                  <h3>Team: {careerData.team.name}</h3>
                  <p>Start Date: {careerData.start}</p>
                  <p>End Date: {careerData.end}</p>
                  <img src={careerData.team.logo} alt={careerData.team.name} />
                </li>
              ))}
            </ul>
          </div>
        )}
      </header>
    </div>
  );
};

export default CoachInfo;

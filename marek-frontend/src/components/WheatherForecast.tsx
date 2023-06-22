import axios, { AxiosResponse } from 'axios';
import React, { useEffect, useState } from 'react';

function WheatherForecast() {
    const [wheather, setWheather] = useState();

    useEffect(() => {
        axios.get('https://localhost:7043/WeatherForecast')
            .then((response: AxiosResponse<any>) => {
                //setWheather(response.data);
                console.log(response.data);
            })
    }, [])

    return (
        <div>
            <header>
                <div>wheather</div>
            </header>
        </div>
    );
}

export default WheatherForecast;
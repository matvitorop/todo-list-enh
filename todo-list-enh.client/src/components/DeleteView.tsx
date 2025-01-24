/* eslint-disable @typescript-eslint/no-explicit-any */
import { useEffect, useState } from 'react';

interface Test {
    temperatureC: number;
}

const DeleteView: React.FC = () => {
    const [forecasts, setForecasts] = useState<Test[]>();
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        populateWeatherData();
    }, []);

    async function populateWeatherData() {
        try {
            setIsLoading(true);
            const response = await fetch('https://localhost:7289/WeatherForecast/Delete');
            if (!response.ok) {
                throw new Error(`Failed to fetch data: ${response.statusText}`);
            }
            const data = await response.json();
            setForecasts(data);
        } catch (err: any) {
            setError(err.message || 'An unknown error occurred');
        } finally {
            setIsLoading(false);
        }
    }

    if (isLoading) {
        return <p><em>Loading... Please wait.</em></p>;
    }

    if (error) {
        return <p>Error: {error}</p>;
    }

    return (
        <div>
            <h1 id="tableLabel">Delete View - Weather Forecast</h1>
            <p>This component demonstrates fetching data from the `/WeatherForecast/Delete` endpoint.</p>
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts && forecasts.map((forecast) => (
                        <tr>
                            <td>{forecast.temperatureC}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default DeleteView;

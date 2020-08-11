import * as React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RouteComponentProps, useParams } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store/createStore';
import { WEATHER_FORECASTS_FEATURE_KEY, requestWeatherForecasts, selectForecasts } from '../store/WeatherForecasts';

// At runtime, Redux will merge together...
type WeatherForecastProps = RouteComponentProps<{ startDateIndex: string }>; // ... plus incoming routing parameters

const FetchData: React.FC<WeatherForecastProps> = () => {
  const dispatch = useDispatch();
  const state = useSelector((state: ApplicationState) => state[WEATHER_FORECASTS_FEATURE_KEY])
  const forecasts = selectForecasts(state);
  const {startDateIndex} = useParams<{ startDateIndex: string }>()

  React.useEffect(() => {
    dispatch(requestWeatherForecasts(parseInt(startDateIndex, 10) || 0));
  }, [startDateIndex])

  function renderForecastsTable() {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  function renderPagination() {
    const prevStartDateIndex = (parseInt(startDateIndex) || 0) - 5;
    const nextStartDateIndex = (parseInt(startDateIndex) || 0) + 5;

    return (
      <div className="d-flex justify-content-between">
        <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-data/${prevStartDateIndex}`}>Previous</Link>
        {state.isLoading && <span>Loading...</span>}
        <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-data/${nextStartDateIndex}`}>Next</Link>
      </div>
    );
  }
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Weather forecast</h1>
        <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
        {renderForecastsTable()}
        {renderPagination()}
      </React.Fragment>
    );
}

export default (FetchData);

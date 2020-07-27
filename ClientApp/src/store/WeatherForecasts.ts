import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
  EntityState,
  PayloadAction,
} from '@reduxjs/toolkit';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export interface WeatherForecastsState extends EntityState<WeatherForecast> {
  isLoading: boolean;
  startDateIndex?: number;
}

type FulfilledRequestWeatherForecasts = {
  startDateIndex: number;
  forecasts: WeatherForecast[];
};

export const WEATHER_FORECASTS_FEATURE_KEY = 'weatherForecasts';

export const requestWeatherForecasts = createAsyncThunk<
  FulfilledRequestWeatherForecasts,
  number
>(
  'weatherForecasts/request',
  async (startDateIndex: number, thunkApi) => {
    const response = await fetch(`weatherforecast`, {
      signal: thunkApi.signal,
    });
    const forecasts: WeatherForecast[] = await response.json();

    return { startDateIndex, forecasts };
  },
  {
    condition(startDateIndex: number, thunkApi) {
      const appState = thunkApi.getState() as WeatherForecastsState;

      return startDateIndex !== appState.startDateIndex;
    },
  }
);

const forecastAdapter = createEntityAdapter<WeatherForecast>({
  selectId: (forecast) => forecast.date,
});

const initialState: WeatherForecastsState = forecastAdapter.getInitialState({
  isLoading: false,
});

const weatherForecastSlice = createSlice({
  name: WEATHER_FORECASTS_FEATURE_KEY,
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(requestWeatherForecasts.pending, (state) => {
      state.isLoading = true;
    });
    builder.addCase(
      requestWeatherForecasts.fulfilled,
      (state, action: PayloadAction<FulfilledRequestWeatherForecasts>) => {
        state.startDateIndex = action.payload.startDateIndex;
        state.isLoading = false;
        forecastAdapter.setAll(state, action.payload.forecasts);
      }
    );
    builder.addCase(requestWeatherForecasts.rejected, (state) => {
      state.isLoading = false;
    });
  },
});

export const {
  // ----------------
  // REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
  reducer,
} = weatherForecastSlice;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
export const actionCreators = { requestWeatherForecasts };

export const { selectAll: selectForecasts } = forecastAdapter.getSelectors();

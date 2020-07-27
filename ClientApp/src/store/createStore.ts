import { configureStore, EnhancedStore } from '@reduxjs/toolkit';

import { COUNTER_FEATURE_KEY, CounterState, reducer as counterReducer } from './Counter';
import { reducer as weatherForecastReducer, WEATHER_FORECASTS_FEATURE_KEY, WeatherForecastsState } from './WeatherForecasts';

export interface ApplicationState {
  [COUNTER_FEATURE_KEY]: CounterState;
  [WEATHER_FORECASTS_FEATURE_KEY]: WeatherForecastsState;
}

export type RootStore = EnhancedStore<ApplicationState>;

export default function createStore(preloadedState?: ApplicationState) {
  return configureStore({
    reducer: {
      [COUNTER_FEATURE_KEY]: counterReducer,
      [WEATHER_FORECASTS_FEATURE_KEY]: weatherForecastReducer,
    },
    preloadedState,
    devTools: true,
  });
}

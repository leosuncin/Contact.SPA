import { configureStore, EnhancedStore } from '@reduxjs/toolkit';

import { ApplicationState, reducers } from '.';

export type RootStore = EnhancedStore<ApplicationState>;

export default function createStore(preloadedState?: ApplicationState) {
  return configureStore({
    reducer: reducers,
    preloadedState,
    devTools: true,
  });
}

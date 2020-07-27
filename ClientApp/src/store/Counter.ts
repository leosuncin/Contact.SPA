import { createSlice } from '@reduxjs/toolkit';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.
export interface CounterState {
  count: number;
}

export const COUNTER_FEATURE_KEY = 'counter';

const initialState: CounterState = {
  count: 0,
};

const counterSlice = createSlice({
  name: COUNTER_FEATURE_KEY,
  initialState,
  reducers: {
    increment(state) {
      state.count++;
    },
    decrement(state) {
      state.count--;
    },
  },
});

export const {
  // ----------------
  // REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
  reducer,
  // ----------------
  // ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
  // They don't directly mutate state, but they can have external side-effects (such as loading data).
  actions: actionCreators,
} = counterSlice;

import * as React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RouteComponentProps } from 'react-router';

import { actionCreators, COUNTER_FEATURE_KEY } from '../store/Counter';
import { ApplicationState } from '../store/createStore';

type CounterProps = RouteComponentProps<{}>;

const Counter: React.FC<CounterProps> = () => {
  const { count } = useSelector(
    (state: ApplicationState) => state[COUNTER_FEATURE_KEY]
  );
  const dispatch = useDispatch();

  return (
    <>
      <h1>Counter</h1>

      <p>This is a simple example of a React component.</p>

      <p aria-live="polite">
        Current count: <strong>{count}</strong>
      </p>

      <button
        type="button"
        className="btn btn-primary btn-lg"
        onClick={() => dispatch(actionCreators.increment())}
      >
        Increment
      </button>
    </>
  );
};

export default Counter;

import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';

export default function configureStore(initialState) {
  const reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
  };

  const middleware = [thunk];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (
    isDevelopment &&
    typeof window !== 'undefined' &&
    window.devToolsExtension
  ) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
  });

  return createStore(
    rootReducer,
    initialState,
    compose(
      applyMiddleware(...middleware),
      ...enhancers,
    ),
  );
}

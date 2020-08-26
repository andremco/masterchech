import thunk from 'redux-thunk'

import { createStore, compose, applyMiddleware } from 'redux'

import rootReducer from '../reducers/root'

let store;
export default initialState => {
    if (store) { 
        return store;
    }
    const createdStore = createStore(
                            rootReducer,
                            initialState,
                            compose(applyMiddleware(thunk), window.__REDUX_DEVTOOLS_EXTENSION__()) 
                        );
    store = createdStore;
    return store;
}
import { combineReducers } from 'redux'
import { loading } from "./loading";
import { error } from "./error";
import { categories } from "./categories";
import { menuDescriptions } from "./menuDescriptions";


const rootReducer = combineReducers({ 
    loading,
    error,
    categories,
    menuDescriptions
});

export default rootReducer;
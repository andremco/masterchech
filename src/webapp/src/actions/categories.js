import * as types from '../constants/types'
import API from '../API/API'
import { createError } from './error'
import { loaded, loading } from "./loading";

export function updateCategories(categories) {
    return {
        type: types.categories.GET,
        categories
    }
}

export function getAllCategories() {
    return dispatch => {
        dispatch(loading());
        return API.get("category")
            .then(res => res.json())
            .then(response => {
                if(response && response.data){
                    dispatch(updateCategories(response.data))
                    dispatch(loaded())
                }
            })
            .catch(err => { 
                dispatch(createError(err))
                dispatch(loaded())
            })
    }
}
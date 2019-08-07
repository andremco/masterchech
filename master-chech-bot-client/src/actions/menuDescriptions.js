import * as types from '../constants/types'
import API from '../API/API'
import { createError } from './error'
import { loaded, loading } from "./loading";

export function updateMenuDescriptions(menuDescriptions) {
    return {
        type: types.menuDescriptions.GET,
        menuDescriptions
    }
}

export function createMenuDescription(payload, openModalSuccess) {
    return dispatch => {
        dispatch(loading());
        return API.post("description", payload)
            .then(res => res.json())
            .then(response => {
                dispatch(loaded())
                if(response && response.success){
                    openModalSuccess();
                }
                
            })
            .catch(err => { 
                dispatch(createError(err))
                dispatch(loaded())
            })
    }
}

export function getAllMenuDescriptions() {
    return dispatch => {
        dispatch(loading());
        return API.get("description")
            .then(res => res.json())
            .then(response => {
                dispatch(updateMenuDescriptions(response.data))
                dispatch(loaded())
            })
            .catch(err => { 
                dispatch(createError(err))
                dispatch(loaded())
            })
    }
}

export function deleteMenuDescription(menuDescriptionId) {
    return dispatch => {
        dispatch(loading());
        return API.get("description/" + menuDescriptionId)
            .then(res => res.json())
            .then(response => {
                dispatch(loaded())
            })
            .catch(err => { 
                dispatch(createError(err))
                dispatch(loaded())
            })
    }
}
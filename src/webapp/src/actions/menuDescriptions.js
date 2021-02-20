import * as types from '../constants/types'
import API from '../API/API'
import { createError } from './error'
import { loaded, loading } from "./loading";

export function updateGetMenuDescriptions(menuDescriptions) {
    return {
        type: types.menuDescriptions.GET,
        menuDescriptions
    }
}

export function updateDeleteMenuDescriptions(menuDescriptionId) {
    return {
        type: types.menuDescriptions.DELETE,
        menuDescriptionId
    }
}

export function createMenuDescription(payload, openModalSuccess) {
    return dispatch => {
        dispatch(loading());
        return API.post("api/recipe", payload)
            .then(res => res.json())
            .then(response => {
                dispatch(loaded())
                if(response && response.success){
                    openModalSuccess()
                    dispatch(getAllMenuDescriptions())
                }
            })
            .catch(err => { 
                dispatch(createError(err))
                dispatch(loaded())
            })
    }
}

export function updateMenuDescription(payload, toggleModal) {
    return dispatch => {
        dispatch(loading());
        return API.put("api/recipe", payload)
            .then(res => res.json())
            .then(response => {
                dispatch(loaded())
                if(response && response.success){
                    toggleModal()
                    dispatch(getAllMenuDescriptions())
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
        return API.get("api/recipe")
            .then(res => res.json())
            .then(response => {
                dispatch(updateGetMenuDescriptions(response.data))
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
        return API.delete("api/recipe/" + menuDescriptionId)
            .then(res => res.json())
            .then(response => {
                if(response && response.success){
                    dispatch(getAllMenuDescriptions())
                }
                dispatch(loaded())
            })
            .catch(err => { 
                dispatch(createError(err))
                dispatch(loaded())
            })
    }
}
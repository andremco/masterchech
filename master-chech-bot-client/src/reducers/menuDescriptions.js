import initialState from '../constants/initialState'
import * as types from '../constants/types'

export function menuDescriptions(state = initialState.menuDescriptions, action) {
    switch (action.type) { 
        case types.menuDescriptions.GET: {
            const { menuDescriptions } = action
            let nextState = state
            for (let menuDescription of menuDescriptions) {
                if (!nextState[menuDescription.id]) {
                    nextState[menuDescription.id] = menuDescription
                }
            }
            return nextState
        }
        case types.menuDescriptions.CREATE: { 
            const { menuDescription } = action
            let nextState = Object.assign({}, state)
            nextState[menuDescription.id] = menuDescription
            return nextState
        }
        case types.menuDescriptions.DELETE: { 
            const { menuDescriptionId } = action
            let nextState = state
            return nextState.filter(m => m.id !== menuDescriptionId);
        }
        default: 
            return state
    }
}
import initialState from '../constants/initialState'
import * as types from '../constants/types'

export function menuDescriptions(state = initialState.menuDescriptions, action) {
    switch (action.type) { 
        case types.menuDescriptions.GET: {
            const { menuDescriptions } = action
            return menuDescriptions
        }
        case types.menuDescriptions.CREATE: { 
            const { menuDescription } = action
            let nextState = state
            nextState[nextState.length + 1] = menuDescription
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
import initialState from '../constants/initialState'
import * as types from '../constants/types'

export function categories(state = initialState.categories, action) {
    switch (action.type) { 
        case types.categories.GET: {
            const { categories } = action
            let nextState = Object.assign({}, state)
            for (let category of categories) {
                if (!nextState[category.id]) {
                    nextState[category.id] = category
                }
            }
            return nextState
        }
        case types.categories.CREATE: { 
            const { category } = action
            let nextState = Object.assign({}, state)
            nextState[category.id] = category
            return nextState
        }
        default: 
            return state
    }
}
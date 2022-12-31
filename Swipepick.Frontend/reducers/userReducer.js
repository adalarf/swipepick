const SET_USER = "SET_USER"

const defaultState = {
  currentUser: {},
  isAuth: false
}

export default function userReducer(state = defaultState, action) {
  switch (action.type) {
    case SET_USER:
      return {
        ...state,
        currentUser: action.payload,
        isAuth: true
      }

    default:
      return state
  }
}

export const setUser = userEmail => ({type: SET_USER, payload: userEmail})

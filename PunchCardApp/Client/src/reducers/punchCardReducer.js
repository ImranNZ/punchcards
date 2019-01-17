import {
  ADD_PUNCHCARD,
  GET_PUNCHCARDS,
  GET_PUNCHCARD,
  PUNCHCARD_LOADING
} from "../actions/types";

const initialState = {
  punchCards: [],
  punchCard: {},
  loading: false
};

export default function(state = initialState, action) {
  switch (action.type) {
    case PUNCHCARD_LOADING:
      return {
        ...state,
        loading: true
      };
    case GET_PUNCHCARDS:
      return {
        ...state,
        punchCards: action.payload,
        loading: false
      };
    case GET_PUNCHCARD:
      return {
        ...state,
        punchCard: action.payload,
        loading: false
      };
    case ADD_PUNCHCARD:
      return {
        ...state,
        punchCards: [action.payload, ...state.punchCards]
      };
    default:
      return state;
  }
}

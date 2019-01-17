import axios from "axios";

import {
    ADD_PUNCHCARD,
    GET_ERRORS,
    CLEAR_ERRORS,
    GET_PUNCHCARDS,
    GET_PUNCHCARD,
    PUNCHCARD_LOADING
} from "./types";

// Add punch card
export const addPunchCard = punchCardData => dispatch => {
    dispatch(clearErrors());
    axios
        .post("/api/punchcard", punchCardData)
        .then(res =>
            dispatch({
                type: ADD_PUNCHCARD,
                payload: res.data
            })
        )
        .catch(err =>
            dispatch({
                type: GET_ERRORS,
                payload: err.response.data
            })
        );
};

// Get punch cards
export const getPunchCards = () => dispatch => {
    dispatch(setPunchCardLoading());
    axios
        .get("/api/punchcard")
        .then(res =>
            dispatch({
                type: GET_PUNCHCARDS,
                payload: res.data
            })
        )
        .catch(err =>
            dispatch({
                type: GET_PUNCHCARDS,
                payload: null
            })
        );
};

// Get punch card
export const getPunchCard = id => dispatch => {
    dispatch(setPunchCardLoading());
    axios
        .get(`/api/punchcard/${id}`)
        .then(res =>
            dispatch({
                type: GET_PUNCHCARD,
                payload: res.data
            })
        )
        .catch(err =>
            dispatch({
                type: GET_PUNCHCARD,
                payload: null
            })
        );
};

// Set loading state
export const setPunchCardLoading = () => {
    return {
        type: PUNCHCARD_LOADING
    };
};

// Clear errors
export const clearErrors = () => {
    return {
        type: CLEAR_ERRORS
    };
};
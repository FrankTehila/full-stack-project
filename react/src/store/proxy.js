import { createSlice } from '@reduxjs/toolkit';

const {actions, reducer} = createSlice({
    name: "proxy",
    initialState: {userKind: 0},
     reducers: {
        setUserKind: (state, action) => {
            state.userKind = action.payload; // עדכון המשתנה ב-store
        },
    },
})

export const { setUserKind } = actions; // ייצוא פעולה זו
export default reducer; // ייצוא הרדוסר

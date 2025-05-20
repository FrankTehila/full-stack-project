const {actions, reducer} = createSlice({
    name: "proxy",
    initialState: {userKind: false},
     reducers: {
        setUserKind: (state, action) => {
            state.userKind = action.payload; // עדכון המשתנה ב-store
        },
    },
})

export const { setUserKind } = actions; // ייצוא פעולה זו
export default reducer; // ייצוא הרדוסר

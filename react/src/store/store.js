import { configureStore } from '@reduxjs/toolkit';
import proxyReducer from './proxy';

const store = configureStore({
    reducer: {
        proxy: proxyReducer,
    },
});

export default store;

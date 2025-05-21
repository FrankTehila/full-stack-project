import { useState } from 'react';
import './App.css';
import AddMeeting from './addMeeting/AddMeeting';
import ViewingMeetings from './meetingManagement/ViewingMeetings';
import { BrowserRouter, Routes, Route, NavLink } from 'react-router-dom';
import Home from './home/Home';
import About from './about/About';
import LogIn from './logIn/LogIn';
import { Provider } from 'react-redux';
import store from './store/store'; // עדכן את הנתיב ל-store שלך

function App() {
  return (
    <Provider store={store}>
      <BrowserRouter>
        <nav>
          <ul>
            <li><NavLink to="/" className={({ isActive }) => (isActive ? 'active' : '')}>LogIn</NavLink></li>
            <li><NavLink to="/home" className={({ isActive }) => (isActive ? 'active' : '')}>Home</NavLink></li>
            <li><NavLink to="/about" className={({ isActive }) => (isActive ? 'active' : '')}>About</NavLink></li>
            <li><NavLink to="/addMeeting" className={({ isActive }) => (isActive ? 'active' : '')}>Add Meeting</NavLink></li>
            <li><NavLink to="/viewing-meetings" className={({ isActive }) => (isActive ? 'active' : '')}>Viewing Meetings</NavLink></li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<LogIn />} />
          <Route path="/home" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/addMeeting" element={<AddMeeting />} />
          <Route path="/viewing-meetings" element={<ViewingMeetings />} />
        </Routes>
      </BrowserRouter>
    </Provider>
  );
}

export default App;

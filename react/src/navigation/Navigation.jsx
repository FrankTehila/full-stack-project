import AddMeeting from '../addMeeting/AddMeeting';
import ViewingMeetings from '../meetingManagement/ViewingMeetings';
import { Routes, Route, NavLink } from 'react-router-dom';
import Home from '../home/Home';
import './navigation.css'
const Navigation = () => {
    return (
        <nav>
            <ul>
                <li><NavLink to="/home" className={({ isActive }) => (isActive ? 'active' : '')}>Home</NavLink></li>
                <li><NavLink to="/addMeeting" className={({ isActive }) => (isActive ? 'active' : '')}>Add Meeting</NavLink></li>
                <li><NavLink to="/viewing-meetings" className={({ isActive }) => (isActive ? 'active' : '')}>Viewing Meetings</NavLink></li>
            </ul>
            <Routes>
                <Route path="/home" element={<Home />} />
                <Route path="/addMeeting" element={<AddMeeting />} />
                <Route path="/viewing-meetings" element={<ViewingMeetings />} />
            </Routes>
        </nav>
    );
}

export default Navigation;

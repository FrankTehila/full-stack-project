import AddMeeting from '../addMeeting/AddMeeting';
import ViewingMeetings from '../meetingManagement/ViewingMeetings';
import { Routes, Route, NavLink } from 'react-router-dom';
import Home from '../home/Home';
import './navigation.css';
import MeetingForm from '../addMeeting/MeetingForm';

const Navigation = () => {
    return (
        <>
            <nav>
                <ul>
                    <li><NavLink to="/home" className={({ isActive }) => (isActive ? 'active' : '')}>Home</NavLink></li>
                    <li><NavLink to="/addMeeting" className={({ isActive }) => (isActive ? 'active' : '')}>Add Meeting</NavLink></li>
                    <li><NavLink to="/viewing-meetings" className={({ isActive }) => (isActive ? 'active' : '')}>Viewing Meetings</NavLink></li>
                </ul>
            </nav>
            <main>
                <Routes>
                    <Route path="/home" element={<Home />} />
                    <Route path="/addMeeting" element={<MeetingForm />} />
                    <Route path="/viewing-meetings" element={<ViewingMeetings />} />
                </Routes>
            </main>
        </>
    );
}

export default Navigation;

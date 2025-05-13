import { useState } from 'react'
import './App.css'
import AddMeeting from './addMeeting/AddMeeting'
import ViewingMeetings from './meetingManagement/ViewingMeetings'

function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/addMeeting" element={<AddMeeting />} />
          <Route path="/viewing-meetings" element={<ViewingMeetings />} />
        </Routes>
      </BrowserRouter>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/about">About</Link></li>
          <li><Link to="/addMeeting">Add Meeting</Link></li>
          <li><Link to="/viewing-meetings">Viewing Meetings</Link></li>
        </ul>
      </nav>
    </>
  )
}

export default App;

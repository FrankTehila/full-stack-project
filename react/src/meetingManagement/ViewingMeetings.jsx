import NextMeeting from "./NextMeeting";

const ViewingMeetings = () => {

  return (
    <div>
      <button onClick={<NextMeeting></NextMeeting>}>next meeting</button>
      <button>meetings history</button>
    </div>
  );
}
export default ViewingMeetings;
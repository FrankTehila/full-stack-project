using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IMeetingServiceBL
    {
        public int AddMeeting(IMeetingBL meetingBL, bool isBoard, bool isProjector, int leaderId);
        public bool RemoveMeeting(int meetingId);
        public List<IMeetingBL> GetAllMeetings();
        public IMeetingBL GetMeetingById(int id);
        public bool UpdateMeeting(int id, IMeetingBL meetingBL);
    }
}

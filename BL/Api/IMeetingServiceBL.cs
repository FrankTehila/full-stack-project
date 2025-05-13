using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IMeetingServiceBL
    {
        public bool ScheduleMeeting(string id, DateTime start, DateTime end);
        public bool AddMeeting(IMeetingBL meeting);
        public bool RemoveMeeting(int meetingId);
    }
}

using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface IMeetingService
    {
        bool AddMeeting(Meeting meeting);
        bool RemoveMeeting(int meetingId);
        public Meeting GetMeeting(int meetingId);
    }
}

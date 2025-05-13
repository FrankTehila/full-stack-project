using DAL.models;
using DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.services
{
    public class MeetingService : IMeetingService
    {
        private readonly dbClass _context;

        public MeetingService(dbClass context)
        {
            _context = context;

        }
        public bool AddMeeting(Meeting meeting)
        {
            Meeting m = _context.Meetings.FirstOrDefault(me => me.Id == meeting.Id);
            if (m != null)
            {
                throw new Exception("The meeting already exixt");
            }
            TimeOnly endTime = meeting.StartTime.Add(TimeSpan.FromHours((double)meeting.Duration));
            m = _context.Meetings.FirstOrDefault(me =>
                me.RoomId == meeting.RoomId &&
                me.Date.Date == meeting.Date.Date &&
                me.StartTime < endTime &&
                me.StartTime.Add(TimeSpan.FromHours((double)me.Duration)) > meeting.StartTime);
            if (m != null)
            {
                throw new Exception("There is a meeting at this time and place");
            }
            //בדיקת תקינות שעה בהתאם לשעות פעילות המשרד שכתוב בקובץ ההגדרות (APPSETTING)
            //if()
                _context.Meetings.Add(meeting);
                _context.SaveChanges();
                return true;
        }

        public bool RemoveMeeting(int meetingId)
        {
            Meeting meeting = _context.Meetings.FirstOrDefault(m => m.Id == meetingId);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Meeting GetMeeting(int meetingId)
        {
            Meeting meeting = _context.Meetings.FirstOrDefault(m => m.Id == meetingId);
            if (meeting != null)
            {
                return meeting;
            }
            return null;
        }

    }
}

using DAL.models;
using DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.services.MeetingService;
using Abp.Configuration;

namespace DAL.services
{
    public class MeetingService : IMeetingService
    {
        private readonly dbClass _context;

        public MeetingService(dbClass context)
        {
            _context = context;
        }

        public List<Room> GetRoomsByParameters(bool isBoard, bool isProjector)
        {
            return new List<Room>();
            //return _context.Rooms
            //    .Where(r =>
            //        (!isBoard || r.IsBoard) &&
            //        (!isProjector || r.IsProjector)
            //    )
            //    .ToList();
        }

        public int GetNumOfWorkersByTeamLeaderId(int Id)
        {
            return _context.Employees
                .Where(e => e.LeaderId == Id)
                .Count();
        }

        public bool IsFreeAtTime(Room room, DateTime date, TimeOnly time, decimal duration)
        {
            TimeOnly endTime = time.AddHours((double)duration);
            Meeting m = _context.Meetings.FirstOrDefault(me =>
                me.Date.Date == date.Date &&
                me.StartTime < endTime &&
                me.StartTime.AddHours((double)me.Duration) > time);

            return m == null; // מחזיר true אם אין פגישה, אחרת false
        }


        public bool AddMeeting(IMeeting meeting)
        {
            _context.Meetings.Add((Meeting)meeting);
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

        public Meeting GetNextMeetingByEmployeeId(int employeeId)
        {
            try
            {
                var teamLeaderId = _context.Employees
                    .Where(e => e.Id == employeeId)
                    .Select(e => e.LeaderId)
                    .FirstOrDefault();

                if (teamLeaderId == 0)
                    return null; // לא נמצא ראש צוות

                var meeting = _context.Meetings
                    .Where(m => m.LeaderId == teamLeaderId && m.Date >= DateTime.Now)
                    .OrderBy(m => m.Date)
                    .ThenBy(m => m.StartTime)
                    .FirstOrDefault();

                return meeting;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Meeting> GetAllMeetings()
        {
            return _context.Meetings.ToList();
        }

        public Meeting GetMeetingById(int id)
        {
            return _context.Meetings.FirstOrDefault(m => m.Id == id);
        }

        public bool UpdateMeeting(Meeting meeting)
        {
            var existing = _context.Meetings.FirstOrDefault(m => m.Id == meeting.Id);
            if (existing == null) return false;

            existing.Date = meeting.Date;
            existing.StartTime = meeting.StartTime;
            existing.Duration = meeting.Duration;
            existing.RoomId = meeting.RoomId;

            _context.SaveChanges();
            return true;
        }

    }
}

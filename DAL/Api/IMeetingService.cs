using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface IMeetingService
    {
        public List<Room> GetRoomsByParameters(bool isBoard, bool isProjector);

        public bool IsFreeAtTime(Room room, DateTime date, TimeOnly time, decimal duration);

        public bool AddMeeting(IMeeting meeting);

        public bool RemoveMeeting(int meetingId);

        public Meeting GetMeeting(int meetingId);
        public int GetNumOfWorkersByTeamLeaderId(int Id);

    }
}

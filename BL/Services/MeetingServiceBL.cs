using BL.api;
using DAL.api;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.services;
using BL.models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BL.services
{
    public class MeetingServiceBL : IMeetingServiceBL
    {
        MeetingService _meeting;
        public MeetingServiceBL(MeetingService meeting)
        {
            this._meeting = meeting;
        }

        public int AddMeeting(IMeetingBL meetingBL, bool isBoard, bool isProjector, int leaderId)
        {
            List<Room> matchingRooms = _meeting.GetRoomsByParameters(isBoard, isProjector);
            List<Room> selectedRooms = matchingRooms
                    .Where(room => _meeting.IsFreeAtTime(room, meetingBL.Date, meetingBL.StartTime, meetingBL.Duration))
                    .ToList();
            Room theRoom = selectedRooms.FirstOrDefault(r => _meeting.GetNumOfWorkersByTeamLeaderId(leaderId) <= r.NumOfSeats);

            if (theRoom == null)
            {
                return -1;
            }

            IMeeting newMeeting = new Meeting()
            {
                Room = theRoom,
                Date = meetingBL.Date,
                StartTime = meetingBL.StartTime,
                Duration = meetingBL.Duration,
                LeaderId = leaderId,
            };

            _meeting.AddMeeting(newMeeting);
            return newMeeting.Id;
        }



        //מחזירה את כל הפגישות של עובד מסוים שעוד לא התבצעו
        //public List<Meating> GetAllMeeting(string id)
        // {
        //     List < Meating > meatings= getMeatings(id);
        //     List<Meating> meatingReturn=new List<Meating> ();
        //     for (int i = 0;i< meatings.Count; i++)
        //     {
        //         if (meatings[i].start < DateTime.Now)
        //         {
        //             meatingReturn.Add(meatings[i]);
        //         }

        //     }
        //     return meatingReturn;
        // }
        public bool RemoveMeeting(int meetingId)
        {
            throw new NotSupportedException();
        }
    }


}

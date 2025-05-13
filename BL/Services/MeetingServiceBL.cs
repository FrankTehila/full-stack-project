using BL.api;
using DAL.api;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.api;


namespace BL.services
{
    public class MeetingServiceBL : IMeetingServiceBL
    {
        IMeetingBL _meeting;
        public MeetingServiceBL(IMeetingBL meeting)
        {
            this._meeting = meeting;
        }
        //הפונקציה מקבלת ת.ז. של ראש הצוות זמן התחלה וזמן סיום וקובעת פגישה
        //מחזירה trueאם הצליחה...
        public bool ScheduleMeeting(string id, DateTime start, DateTime end)
        {

            return true;
        }
        //מה להשאיר?
        //public bool AddMeeting(IMeetingBL meeting) 
        //{
        //    return _meeting.AddMeeting(meeting);
        //}

        public bool AddMeeting(IMeetingBL meeting)
        {
            throw new NotImplementedException();
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

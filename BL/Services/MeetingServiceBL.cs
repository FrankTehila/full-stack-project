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
        TeamLeaderService _teamLeaderService;
        EmployeeService _employeeService;
        EmailService _emailService;

        public MeetingServiceBL(
            MeetingService meeting,
            TeamLeaderService teamLeaderService,
            EmployeeService employeeService,
            EmailService emailService)
        {
            _meeting = meeting;
            _teamLeaderService = teamLeaderService;
            _employeeService = employeeService;
            _emailService = emailService;
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

            _teamLeaderService.AddMeetingToTeamLeader((Meeting)newMeeting);
            TeamLeader teamLeader = _teamLeaderService.GetTeamLeaderByID(leaderId);


            var employees = _employeeService.GetEmployeesByLeaderId(leaderId);
            List<string> emails = employees.Select(e => e.Email).ToList();
            emails.Add(teamLeader.Email);

            string subject = "זימון לפגישה חדשה";
            string body = $@"
        שלום,<br/>
        הוזמנתם לפגישה בתאריך: {newMeeting.Date:dd/MM/yyyy} בשעה: {newMeeting.StartTime}<br/>
        משך: {newMeeting.Duration} שעות<br/>
        חדר: {newMeeting.Room.Id}<br/>
        ראש צוות: {teamLeader.FirstName} {teamLeader.LastName}<br/>
        <br/>
        בברכה,<br/>
        מערכת ניהול פגישות";

            EmailService emailService = new EmailService();
            foreach (var email in emails)
            {
                emailService.SendRandomCodeEmail(email, subject, body);
            }

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

        public Meeting GetEmployeeNextMeeting(int employeeId)
        {
            try
            {
                var meeting = _meeting.GetNextMeetingByEmployeeId(employeeId);

                if (meeting == null)
                    throw new Exception("No meeting found in the near future.");

                return meeting;
            }
            catch (Exception ex)
            {
                // אפשר לרשום ללוג, או לזרוק חריג עסקי
                // throw new BusinessException("בעיה בקבלת פגישה לעובד", ex);
                throw;
            }
        }
    }


}

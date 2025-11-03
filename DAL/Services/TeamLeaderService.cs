using DAL.api;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.services
{
    public class TeamLeaderService
    {
        private readonly dbClass _context;
        public TeamLeaderService(dbClass context)
        {
            _context = context;
        }
        public bool IsItTeamLeader(int ID)
        {
            int teamLeaderID = _context.TeamLeaders.FirstOrDefault(tl => tl.Id == ID).Id;
            if (teamLeaderID == null)
            {
                teamLeaderID = _context.Employees.FirstOrDefault(tl => tl.Id == ID).Id;
                if (teamLeaderID == null)
                {
                    throw new Exception("Employee does not exist");
                }
                return false;
            }
            return true;
        }

        public bool AddTeamLeader(ITeamLeader teamLeader)
        {
            Console.WriteLine($"🔍 [DAL] AddTeamLeader נקרא עבור ID: {teamLeader.Id}");
            
            TeamLeader teamLeaderInBD = _context.TeamLeaders.FirstOrDefault(r => r.Id == teamLeader.Id);
            if (teamLeaderInBD != null)
            {
                Console.WriteLine($"❌ [DAL] ראש צוות כבר קיים: {teamLeader.Id}");
                throw new Exception("The teamLeader already exists");
            }

            if (teamLeader is TeamLeader newTeamLeader)
            {
                Console.WriteLine($"✅ [DAL] מוסיף ראש צוות חדש: {newTeamLeader.Id}, {newTeamLeader.FirstName} {newTeamLeader.LastName}");
                _context.TeamLeaders.Add(newTeamLeader);
                
                int changesSaved = _context.SaveChanges();
                Console.WriteLine($"✅ [DAL] SaveChanges הושלם. שורות שנשמרו: {changesSaved}");
                
                return true;
            }
            else
            {
                Console.WriteLine($"❌ [DAL] טיפוס ראש צוות לא תקין");
                throw new Exception("Invalid teamLeader type");
            }
        }

        public bool RemoveTeamLeader(int teamLeaderID)
        {
            Console.WriteLine($"🔍 [DAL] RemoveTeamLeader נקרא עבור ID: {teamLeaderID}");
            
            TeamLeader teamLeaderInDB = _context.TeamLeaders.FirstOrDefault(r => r.Id == teamLeaderID);
            if (teamLeaderInDB == null)
            {
                Console.WriteLine($"❌ [DAL] ראש צוות לא נמצא: {teamLeaderID}");
                throw new Exception("The teamLeader does not exist");
            }
            
            Console.WriteLine($"✅ [DAL] ראש צוות נמצא, מוחק: {teamLeaderID}");
            _context.TeamLeaders.Remove(teamLeaderInDB);
            
            int changesSaved = _context.SaveChanges();
            Console.WriteLine($"✅ [DAL] SaveChanges הושלם. שורות שנמחקו: {changesSaved}");
            
            return true;
        }

        public TeamLeader GetTeamLeaderByID(int teamLeaderID)
        {
            TeamLeader teamLeaderInDB = _context.TeamLeaders.FirstOrDefault(r => r.Id == teamLeaderID);
            if (teamLeaderInDB == null)
            {
                throw new Exception("The teamLeader does not exist");
            }
            return teamLeaderInDB;

        }
        public bool AddMeetingToTeamLeader(Meeting meeting)
        {
            TeamLeader teamLeader = _context.TeamLeaders.FirstOrDefault(tl => tl.Id == meeting.LeaderId);
            if (teamLeader == null)
            {
                throw new Exception("Team leader does not exist");
            }
            teamLeader.Meetings.Add(meeting);
            _context.SaveChanges();
            return true;
        }
    }
}

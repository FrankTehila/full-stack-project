using DAL.api;
using DAL.models;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
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
            TeamLeader teamLeaderInBD = _context.TeamLeaders.FirstOrDefault(r => r.Id == teamLeader.Id);
            if (teamLeaderInBD != null)
            {
                throw new Exception("The teamLeader already exists");
            }

            if (teamLeader is TeamLeader newTeamLeader)
            {
                _context.TeamLeaders.Add(newTeamLeader);
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Invalid teamLeader type");
            }
        }

        public bool RemoveTeamLeader(int teamLeaderID)
        {
            TeamLeader teamLeaderInDB = _context.TeamLeaders.FirstOrDefault(r => r.Id == teamLeaderID);
            if (teamLeaderInDB == null)
            {
                throw new Exception("The teamLeader does not exist");
            }
            _context.TeamLeaders.Remove(teamLeaderInDB);
            _context.SaveChanges();
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
    }
}

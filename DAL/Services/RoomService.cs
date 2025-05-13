using Abp.Configuration;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Services
{
    public class RoomService
    {
        private readonly dbClass _context;
        public RoomService(dbClass context)
        {
            _context = context;

        }
        public Room GetRoom(int roomId)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                return room;
            }
            return null;
        }
    }
}

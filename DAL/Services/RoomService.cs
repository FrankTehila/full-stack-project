using Abp.Configuration;
using DAL.api;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Services
{
    public class RoomService : IRoomService
    {
        private readonly dbClass _context;
        public RoomService(dbClass context)
        {
            _context = context;

        }

        public bool AddRoom(IRoom room)
        {
            Room roomInDB = _context.Rooms.FirstOrDefault(r => r.Id == room.Id);
            if (roomInDB != null)
            {
                throw new Exception("The room already exists");
            }

            if (room is Room newRoom)
            {
                _context.Rooms.Add(newRoom);
                _context.SaveChanges(); // הוסף כאן את השמירה
                return true;
            }
            else
            {
                throw new Exception("Invalid room type");
            }
        }

        public bool RemoveRoom(int roomID)
        {
            Room roomInDB = _context.Rooms.FirstOrDefault(r => r.Id == roomID);
            if (roomInDB != null)
            {
                throw new Exception("The room does not exist"); // שגיאה אם החדר לא קיים
            }
            _context.Rooms.Remove(roomInDB);
            _context.SaveChanges(); // הוסף כאן את השמירה
            return true;
        }

        public Room GetRoomByID(int roomId)
        {
            Room room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            return room;
        }

    }
}

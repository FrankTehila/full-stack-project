using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.api
{
    public interface IRoomService
    {
        public bool AddRoom(IRoom room);
        public bool RemoveRoom(int roomID);
        public Room GetRoomByID(int roomId);
    }
}

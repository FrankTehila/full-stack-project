using BL.models;
using DAL.api;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.api
{
    public interface IRoomServiceBL
    {
        public Room GetRoomByID(int roomId);
        public bool AddRoom(IRoomBL room);
        public bool RemoveRoom(int roomID);
       
}
}

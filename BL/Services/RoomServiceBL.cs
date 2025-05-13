using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.api;
using BL.api;
using BL.Models;


namespace BL.services
{

    public class RoomServiceBL : IRoomServiceBL
    {

        IRoomService _roomDAL;
        public RoomServiceBL(IRoomService roomDAL)
        {
            _roomDAL = roomDAL;
        }
        public IRoomBL GetRoom(int roomId)
        {
            DAL.models.Room roomDAL = _roomDAL.getRoom(roomId);
            return MapToRoomBL(roomDAL);

        }
        private IRoomBL MapToRoomBL(DAL.models.Room roomDAL)
        {
            return new RoomBL()
            {
                Id = roomDAL.Id,
                NumOfSeats = roomDAL.NumOfSeats,
                NumOfComputers = roomDAL.NumOfComputers,
                IsProjector = roomDAL.IsProjector,
                IsBoard = roomDAL.IsBoard,
                Meetings = roomDAL.Meetings
            };
        }

    }
    //using DAL.models;
    //using System;
    //using System.Collections.Generic;
    //using DAL.api;
    //using BL.api;

    //namespace BL.services
    //{
    //    public class RoomServiceBL : IRoomServiceBL
    //    {
    //        private readonly IRoomService _roomDAL;

    //        public RoomServiceBL(IRoomService roomDAL)
    //        {
    //            _roomDAL = roomDAL ?? throw new ArgumentNullException(nameof(roomDAL));
    //        }

    //        public IRoomBL GetRoom(int roomId)
    //        {
    //            var roomDAL = _roomDAL.getRoom(roomId); // Ensure the method name matches the interface
    //            if (roomDAL == null)
    //            {
    //                throw new KeyNotFoundException($"Room with ID {roomId} was not found.");
    //            }

    //            // Assuming a mapping from DAL.models.Room to BL.api.IRoomBL
    //            return MapToRoomBL(roomDAL);
    //        }

    //        public IRoomBL getRoom(int roomId)
    //        {
    //            throw new NotImplementedException();
    //        }

    //        private IRoomBL MapToRoomBL(DAL.models.Room roomDAL)
    //        {
    //            // Implement the mapping logic here
    //            // Example: return new RoomBL { Id = roomDAL.Id, Name = roomDAL.Name };
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}

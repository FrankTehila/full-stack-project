using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.api;
using BL.api;
using BL.models;


namespace BL.services
{

    public class RoomServiceBL : IRoomServiceBL
    {

        IRoomService _roomDAL;
        public RoomServiceBL(IRoomService roomDAL)
        {
            _roomDAL = roomDAL;
        }
        public Room GetRoomByID(int roomId)
        {
            return _roomDAL.GetRoomByID(roomId);
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
        private Room MapToRoomDAL(IRoomBL roomBL)
        {
            return new Room()
            {
                Id = roomBL.Id,
                NumOfSeats = roomBL.NumOfSeats,
                NumOfComputers = roomBL.NumOfComputers,
                IsProjector = roomBL.IsProjector,
                IsBoard = roomBL.IsBoard,
                Meetings = roomBL.Meetings
            };
        }
        public bool AddRoom(IRoomBL room)
        {
            Room roomDAL = MapToRoomDAL(room);
            return _roomDAL.AddRoom(roomDAL);
        }

        public bool RemoveRoom(int roomID)
        {
            return _roomDAL.RemoveRoom(roomID);
        }

        public bool UpdateRoom(int roomId, RoomBL updatedRoom)
        {
            var existingRoom = _roomDAL.GetRoomByID(roomId);
            if (existingRoom == null)
            {
                throw new Exception($"Room with ID {roomId} does not exist");
            }

            // עדכון רק השדות שסופקו בבקשה עם בדיקה האם יש ערך (HasValue)
            if (updatedRoom.NumOfSeats.HasValue)
            {
                existingRoom.NumOfSeats = updatedRoom.NumOfSeats.Value;
            }

            if (updatedRoom.NumOfComputers.HasValue)
            {
                existingRoom.NumOfComputers = updatedRoom.NumOfComputers.Value;
            }

            if (updatedRoom.IsProjector.HasValue)
            {
                existingRoom.IsProjector = updatedRoom.IsProjector.Value;
            }

            if (updatedRoom.IsBoard.HasValue)
            {
                existingRoom.IsBoard = updatedRoom.IsBoard.Value;
            }

            return _roomDAL.UpdateRoom(existingRoom);
        }

    }

}

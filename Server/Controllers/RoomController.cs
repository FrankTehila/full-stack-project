using DAL.api;
using Microsoft.AspNetCore.Mvc;
using BL.api;
using BL.models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        IRoomServiceBL _IRoomBL;
        public RoomController(IRoomServiceBL IRoomBL)
        {
            _IRoomBL = IRoomBL;
        }

        [HttpGet]
        public IActionResult GetRoom(int roomId)
        {

            if (_IRoomBL.GetRoomByID(roomId) != null)
            {
                return Ok(_IRoomBL.GetRoomByID(roomId));
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddRoom([FromBody] RoomBL room)
        {
            _IRoomBL.AddRoom(room);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int roomId)
        {
            if (_IRoomBL.RemoveRoom(roomId))
            {
                return Ok($"Room No. {roomId} was successfully deleted.");
            }
            return BadRequest($"Room No. {roomId} was not found.");
        }



        [HttpPut]
        public IActionResult UpdateRoom([FromBody] RoomBL updatedRoom)
        {
            if (updatedRoom == null || updatedRoom.Id < 0)
            {
                Console.WriteLine(" שגיאה: הנתונים שהתקבלו אינם תקינים או חסר ID");
                return BadRequest("Invalid room data or missing ID.");
            }

            Console.WriteLine($" עדכון חדר - ID שהתקבל: {updatedRoom.Id}");

            var existingRoom = _IRoomBL.GetRoomByID(updatedRoom.Id);
            if (existingRoom == null)
            {
                Console.WriteLine($" חדר עם ID {updatedRoom.Id} לא נמצא");
                return NotFound($"Room with ID {updatedRoom.Id} not found.");
            }

            _IRoomBL.UpdateRoom(updatedRoom.Id, updatedRoom);
            Console.WriteLine($" חדר {updatedRoom.Id} עודכן בהצלחה");

            return Ok($"Room No. {updatedRoom.Id} updated successfully.");
        }
    }
}

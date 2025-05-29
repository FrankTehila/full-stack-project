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
             
            if (_IRoomBL.GetRoomByID(roomId)!=null)
            {
                return Ok(_IRoomBL.GetRoomByID(roomId));
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddRoom([FromBody]RoomBL room)
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
    }
}

using DAL.api;
using Microsoft.AspNetCore.Mvc;
using BL.api;
using BL.Models;
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
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddRoom([FromBody]RoomBL room)
        {       
            _IRoomBL.AddRoom(room); 
            return Ok(); 
        }
    }
}

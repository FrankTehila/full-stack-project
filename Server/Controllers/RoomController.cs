using DAL.api;
using Microsoft.AspNetCore.Mvc;
using BL.api;

namespace Server.Controllers
{
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
            
            if (_IRoomBL.GetRoom(roomId)!=null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

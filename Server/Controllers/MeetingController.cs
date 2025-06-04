using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BL.api;
using BL.models;
using Microsoft.AspNetCore.Authorization;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private IMeetingServiceBL meetingServiceBL;
        private static int id = 0;

        public MeetingController(IMeetingServiceBL _meetingServiceBL)
        {
            meetingServiceBL = _meetingServiceBL;
        }

        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddMeeting([FromBody] MeetingBL meetingBL, bool isBoard, bool isProjector, int leaderId)
        {
            // שלוף מהטוקן את ה-userKind
            var userKindClaim = User.Claims.FirstOrDefault(c => c.Type == "userKind");
            if (userKindClaim == null || userKindClaim.Value == "0")
            {
                return Forbid("רק ראש צוות מורשה להוסיף פגישה");
            }

            // אפשר גם לשלוף את ה-id של ראש הצוות מהטוקן אם רוצים ולא מהקליינט
            // var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            int roomNum = meetingServiceBL.AddMeeting(meetingBL, isBoard, isProjector, leaderId);

            return roomNum == -1
                ? Ok($"Error! The meeting was not added.")
                : Ok($"The meeting added successfully in room number {roomNum}.");
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] string id)
        {
            if (int.TryParse(id, out int intId))
            {
                if (meetingServiceBL.RemoveMeeting(intId))
                {
                    return Ok($"The meeting deleted successfully.");
                }
                else
                {
                    return BadRequest("No suitable meeting was found for deletion.");
                }
            }
            else
            {
                return BadRequest("Invalid ID format. ID must be an integer.");
            }
        }

        //[HttpGet(${id})]

    }
}
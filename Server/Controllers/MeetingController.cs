using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BL.api;
using BL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpPost("Add")]
        public IActionResult AddMeeting([FromBody] JsonElement json)
        {
            var meeting = JsonSerializer.Deserialize<MeetingBL>(json.GetRawText());
            meeting.Id = id++;

            if (!TryValidateModel(meeting))
            {
                return BadRequest("Some data is missing or inconsistent.");
            }
            if (meetingServiceBL.AddMeeting(meeting))
            {
                return Ok($"Meeting {meeting.Id} added successfully!!");
            }
            else
            {
                return BadRequest($"Meeting {meeting.Id} was not added.");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string id)
        {
            if (int.TryParse(id, out int intId))
            {
                if (meetingServiceBL.RemoveMeeting(intId))
                {
                    return Ok($"Item with ID {intId} deleted successfully.");
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
    }
}
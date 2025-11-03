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
            // ���� ������ �� �-userKind
            var userKindClaim = User.Claims.FirstOrDefault(c => c.Type == "userKind");
            if (userKindClaim == null || userKindClaim.Value == "0")
            {
                return Forbid("�� ��� ���� ����� ������ �����");
            }

            // ���� �� ����� �� �-id �� ��� ����� ������ �� ����� ��� ��������
            // var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            int roomNum = meetingServiceBL.AddMeeting(meetingBL, isBoard, isProjector, leaderId);

            return roomNum == -1
                ? Ok($"Error! The meeting was not added.")
                : Ok($"The meeting added successfully in room number {roomNum}.");
        }


        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var userKindClaim = User.Claims.FirstOrDefault(c => c.Type == "userKind");
            if (userKindClaim == null || userKindClaim.Value == "0")
            {
                return Forbid("אין לך הרשאה למחוק פגישות");
            }

            if (meetingServiceBL.RemoveMeeting(id))
            {
                return Ok($"The meeting deleted successfully.");
            }
            else
            {
                return BadRequest("No suitable meeting was found for deletion.");
            }
        }

        [HttpGet]
        public IActionResult GetAllMeetings()
        {
            try
            {
                var meetings = meetingServiceBL.GetAllMeetings();
                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMeetingById(int id)
        {
            try
            {
                var meeting = meetingServiceBL.GetMeetingById(id);
                if (meeting == null)
                {
                    return NotFound($"Meeting with ID {id} not found.");
                }
                return Ok(meeting);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateMeeting(int id, [FromBody] MeetingBL meetingBL)
        {
            var userKindClaim = User.Claims.FirstOrDefault(c => c.Type == "userKind");
            if (userKindClaim == null || userKindClaim.Value == "0")
            {
                return Forbid("אין לך הרשאה לעדכן פגישות");
            }

            try
            {
                bool updated = meetingServiceBL.UpdateMeeting(id, meetingBL);
                if (updated)
                {
                    return Ok("Meeting updated successfully.");
                }
                else
                {
                    return NotFound($"Meeting with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
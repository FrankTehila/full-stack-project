using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BL.api;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeServiceBL _employeeServiceBL;

        public LoginController(IEmployeeServiceBL employeeServiceBL)
        {
            _employeeServiceBL = employeeServiceBL;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Dictionary<string, int> request)
        {
            try
            {
                if (request == null || !request.ContainsKey("Id"))
                    return BadRequest("Invalid request");

                int id = request["Id"];
                int userKind = _employeeServiceBL.IsItTeamLeader(id);

                // הפקת טוקן לכל משתמש שנמצא (גם עובד פשוט וגם ראש צוות)
                var tokenService = new TokenService();
                var token = tokenService.GenerateToken(id, userKind.ToString());

                return Ok(new { userKind, token });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


    }
}
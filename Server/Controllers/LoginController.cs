using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BL.api;
using BL.services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeServiceBL _employeeServiceBL;
        private readonly TokenService _tokenService;
        private readonly VerificationCodeService _verificationCodeService;

        public LoginController(IEmployeeServiceBL employeeServiceBL, TokenService tokenService, 
            VerificationCodeService verificationCodeService)
        {
            _employeeServiceBL = employeeServiceBL;
            _tokenService = tokenService;
            _verificationCodeService = verificationCodeService;
        }

        /// <summary>
        /// שלב 1: התחברות ראשונית - בודק אם המשתמש קיים
        /// </summary>
        [HttpPost]
        public IActionResult Login([FromBody] Dictionary<string, int> request)
        {
            try
            {
                if (request == null || !request.ContainsKey("Id"))
                    return BadRequest("Invalid request");

                int id = request["Id"];
                int userKind = _employeeServiceBL.IsItTeamLeader(id);

                if (userKind == 0)
                {
                    // עובד רגיל - מחזיר טוקן ישירות
                    var token = _tokenService.GenerateToken(id, "0");
                    return Ok(new { userKind = 0, token });
                }
                else
                {
                    // ראש צוות - שלח קוד במייל (הקוד כבר נשמר ב-EmployeeServiceBL)
                    return Ok(new { userKind = 1, message = "Verification code sent to your email" });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// שלב 2: אימות קוד לראש צוות - מקבל ID וקוד, מחזיר טוקן רק אם הקוד נכון
        /// </summary>
        [HttpPost("verify")]
        public IActionResult VerifyCode([FromBody] VerificationRequest request)
        {
            try
            {
                if (request == null || request.Id <= 0 || request.Code <= 0)
                    return BadRequest("Invalid request");

                // בודק אם הקוד נכון
                bool isValid = _verificationCodeService.VerifyCode(request.Id, request.Code);

                if (!isValid)
                {
                    return Unauthorized(new { message = "Invalid or expired verification code" });
                }

                // קוד נכון - יוצר טוקן
                var token = _tokenService.GenerateToken(request.Id, "1");
                return Ok(new { userKind = 1, token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

    // מודל לבקשת אימות
    public class VerificationRequest
    {
        public int Id { get; set; }
        public int Code { get; set; }
    }
}
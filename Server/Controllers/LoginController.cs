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
            if (request == null || !request.ContainsKey("Id"))
            {
                return BadRequest("Invalid request");
            }

            int id = request["Id"];
            return Ok(_employeeServiceBL.IsItTeamLeader(id));
        }
       

	}
}
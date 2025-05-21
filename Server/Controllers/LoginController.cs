using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BL.api;

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
	public IActionResult Login([FromBody] int id)
	{
		return Ok(_employeeServiceBL.IsItTeamLeader(id));
	}

}
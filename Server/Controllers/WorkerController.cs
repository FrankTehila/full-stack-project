using BL.api;
using BL.models;
using DAL.api;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IEmployeeServiceBL _employeeServiceBL;

        private readonly ITeamLeaderBL _teamLeaderBL;
        public WorkerController(IEmployeeServiceBL employeeServiceBL)
        {
            _employeeServiceBL = employeeServiceBL;
            
        }
        [HttpPost]
        public IActionResult AddWorker([FromBody] JsonElement workerData)
        {
            // זיהוי סוג העובד לפי השדות הקיימים
            if (workerData.TryGetProperty("NumOfWorkers", out _))
            {
                TeamLeaderBL worker = JsonSerializer.Deserialize<TeamLeaderBL>(workerData.GetRawText());

                return _employeeServiceBL.AddWorker(worker)
                    ? Ok($"Team Leader {worker.Id} was added successfully.")
                    : BadRequest($"Team Leader {worker.Id} could not be added.");
            }
            else if (workerData.TryGetProperty("LeaderId", out _))
            {
                EmployeeBL worker = JsonSerializer.Deserialize<EmployeeBL>(workerData.GetRawText());

                return _employeeServiceBL.AddWorker(worker)
                    ? Ok($"Employee {worker.Id} was added successfully.")
                    : BadRequest($"Employee {worker.Id} could not be added.");
            }

            // אם הנתונים לא מתאימים לאף סוג - מחזירים שגיאה
            return BadRequest("Error: Worker data does not match any known type (Employee or Team Leader).");
        }
    }
}

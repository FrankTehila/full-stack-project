using BL.models;
using BL.api;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BL.models.BL.models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IEmployeeServiceBL _employeeServiceBL;

        public WorkerController(IEmployeeServiceBL employeeServiceBL)
        {
            _employeeServiceBL = employeeServiceBL;
        }

        [HttpPost]
        public IActionResult AddWorker([FromBody] JsonElement workerData)
        {
            Console.WriteLine($"🔍 JSON שהתקבל: {workerData.GetRawText()}");

            try
            {
                // בדוק אם יש numOfWorkers - זה ראש צוות
                if (workerData.TryGetProperty("numOfWorkers", out var _))
                {
                    var teamLeaderDto = JsonSerializer.Deserialize<TeamLeaderDTO>(workerData.GetRawText());
                    if (teamLeaderDto == null)
                        return BadRequest("TeamLeaderDTO is null!");

                    Console.WriteLine($"[DTO] TeamLeader: {teamLeaderDto.Id}, {teamLeaderDto.Email}");

                    // המרת DTO ל-BL
                    TeamLeaderBL teamLeaderBL = new TeamLeaderBL
                    {
                        Id = teamLeaderDto.Id,
                        NumOfWorkers = teamLeaderDto.NumOfWorkers,
                        Email = teamLeaderDto.Email,
                        FirstName = teamLeaderDto.FirstName,
                        LastName = teamLeaderDto.LastName,
                        Meetings = null // לא שולחים פגישות מהלקוח
                    };

                    Console.WriteLine($"[BL] TeamLeader: {teamLeaderBL.Id}, {teamLeaderBL.Email}");

                    bool success = _employeeServiceBL.AddWorker(teamLeaderBL);

                    if (success)
                        return Ok($"TeamLeader {teamLeaderBL.Id} was added successfully.");
                    else
                        return BadRequest($"TeamLeader {teamLeaderBL.Id} could not be added.");
                }
                // אחרת - עובד רגיל
                else
                {
                    var employeeDto = JsonSerializer.Deserialize<EmployeeDTO>(workerData.GetRawText());
                    if (employeeDto == null)
                        return BadRequest("EmployeeDTO is null!");

                    Console.WriteLine($"[DTO] Employee: {employeeDto.Id}, {employeeDto.Email}");

                    EmployeeBL employeeBL = new EmployeeBL
                    {
                        Id = employeeDto.Id,
                        Email = employeeDto.Email,
                        FirstName = employeeDto.FirstName,
                        LastName = employeeDto.LastName,
                        LeaderId = employeeDto.LeaderId ?? 0
                    };

                    Console.WriteLine($"[BL] Employee: {employeeBL.Id}, {employeeBL.Email}");

                    bool success = _employeeServiceBL.AddWorker(employeeBL);

                    if (success)
                        return Ok($"Employee {employeeBL.Id} was added successfully.");
                    else
                        return BadRequest($"Employee {employeeBL.Id} could not be added.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ שגיאה ב-AddWorker: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{workerId}")]
        public IActionResult RemoveWorker(int workerId)
        {
            if (_employeeServiceBL.RemoveWorker(workerId))
            {
                Console.WriteLine($"✅ עובד נמחק בהצלחה - ID: {workerId}");
                return Ok($"Worker {workerId} was removed successfully.");
            }

            Console.WriteLine($"❌ מחיקת עובד נכשלה - ID: {workerId}");
            return BadRequest($"Worker {workerId} could not be removed.");
        }

    }
}
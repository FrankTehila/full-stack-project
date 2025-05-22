using BL.api;

using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IEmployeeServiceBL _employeeServiceBL;

        public WorkerController(IEmployeeServiceBL employeeServiceBL)
        {
            _employeeServiceBL = employeeServiceBL;
        }

        [HttpPost]
        public IActionResult AddWorker(IWorkerBL worker)
        {
          if(_employeeServiceBL.AddWorker(worker))
            {
                return Ok($"the worker {worker.Id} was added succesfully.");
            }
            return BadRequest($"the worker {worker.Id} was not added.");
        }
    }
}

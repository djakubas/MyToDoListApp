using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyToDoListApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class Controller : ControllerBase
    {

        private readonly ILogger<TasksController> _logger;
        public Controller(ILogger<TasksController> logger)
        {
            _logger = logger;
        }
        [EnableCors("CorsPolicyLocalFile")]
        [Route("/{**catchAll}")]
        [HttpGet]
        public IActionResult Get(string catchAll)
        {
            return BadRequest();
        }
        
    }
}

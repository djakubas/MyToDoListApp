using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyToDoListApp.Tables;
using MyToDoListApp.TablesService;
using System.Net;

namespace MyToDoListApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusesController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        public StatusesController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [EnableCors("CorsPolicyLocalFile")]
        [HttpGet()]
        public IEnumerable<TableStatuses> Get()
        {
            var MyToDoListStatus = TableStatusesService.Get();
            return MyToDoListStatus;
        }
    }
     
}

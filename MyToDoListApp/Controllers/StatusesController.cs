using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using MyToDoListApp.Tables;
using MyToDoListApp.TablesService;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MyToDoListApp.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly DBService _context;
        private readonly ILogger<TasksController> _logger;
        public StatusesController(ILogger<TasksController> logger, DBService context)
        {
            _logger = logger;
            _context = context;
        }

        [EnableCors("CorsPolicyLocalFile")]
        [HttpGet()]
        [RequiredScope("Statuses.Read")]
        public IEnumerable<TableStatuses> Get()
        {
            var MyToDoListStatus = TableStatusesService.Get(_context);
            return MyToDoListStatus;
        }
    }
     
}

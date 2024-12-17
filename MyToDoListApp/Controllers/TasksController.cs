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
    public class TasksController : ControllerBase
    {
        private readonly DBService _context;
        
        private readonly ILogger<TasksController> _logger;
        public TasksController(ILogger<TasksController> logger, DBService context)
        {
            _logger = logger;
            _context = context;
        }

        [EnableCors("CorsPolicyGitHub")]
        [HttpGet()]
        [RequiredScope("Tasks.Read")]
        public IEnumerable<TableTask> Get()
        {
            var MyToDoListTask = TableTaskService.Get(_context);
            return MyToDoListTask;
        }

        [EnableCors("CorsPolicyGitHub")]
        [HttpGet("{id}")]
        [RequiredScope("Tasks.Read")]
        public ActionResult<TableTask> Get(int id)
        {
            var MyToDoListTask = TableTaskService.Get(id, _context);

            if (MyToDoListTask == null)
                return NotFound();

            return MyToDoListTask;
        }
        [EnableCors("CorsPolicyGitHub")]
        [HttpPost]
        [RequiredScope("Tasks.Write")]
        public IActionResult Create(TableTask task)
        {
            if (TableTaskService.Add(task, _context))
                return CreatedAtAction(nameof(Get), new { TaskId = task.TaskId }, task);
            else 
                return BadRequest();
            
        }
        [EnableCors("CorsPolicyGitHub")]
        [HttpPut("{id}")]
        [RequiredScope("Tasks.Write")]
        public IActionResult Create(int id, TableTask task)
        {
            if (id != task.TaskId)
                return BadRequest();

            var ExistingTask = TableTaskService.Get(id, _context);

            if (ExistingTask is null)
                return NotFound();

            if (TableTaskService.Update(task, _context))
                return NoContent();
            else
                //return StatusCode(500);
                return NotFound();
        }

        [EnableCors("CorsPolicyGitHub")]
        [HttpDelete("{id}")]
        [RequiredScope("Tasks.Write")]
        public IActionResult Delete(int id)
        {
            var ExistingTask = TableTaskService.Get(id, _context);

            if (ExistingTask is null)
                return NotFound();  
            else
                TableTaskService.Delete(ExistingTask, _context);
                return NoContent();
        }

    }
}

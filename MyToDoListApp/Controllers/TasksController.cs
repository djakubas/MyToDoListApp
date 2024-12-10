using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyToDoListApp.Tables;
using MyToDoListApp.TablesService;
using System.Net;

namespace MyToDoListApp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [EnableCors("CorsPolicyLocalFile")]
        [HttpGet()]
        public IEnumerable<TableTask> Get()
        {
            var MyToDoListTask = TableTaskService.Get();
            return MyToDoListTask;
        }

        [EnableCors("CorsPolicyLocalFile")]
        [HttpGet("{id}")]
        public ActionResult<TableTask> Get(int id)
        {
            var MyToDoListTask = TableTaskService.Get(id);

            if (MyToDoListTask == null)
                return NotFound();

            return MyToDoListTask;
        }
        [EnableCors("CorsPolicyLocalFile")]
        [HttpPost]
        public IActionResult Create(TableTask task)
        {
            if (TableTaskService.Add(task))
                return CreatedAtAction(nameof(Get), new { TaskId = task.TaskId }, task);
            else 
                return BadRequest();
            
        }
        [EnableCors("CorsPolicyLocalFile")]
        [HttpPut("{id}")]
        public IActionResult Create(int id, TableTask task)
        {
            if (id != task.TaskId)
                return BadRequest();

            var ExistingTask = TableTaskService.Get(id);

            if (ExistingTask is null)
                return NotFound();

            if (TableTaskService.Update(task))
                return NoContent();
            else
                return StatusCode(500);
        }

        [EnableCors("CorsPolicyLocalFile")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ExistingTask = TableTaskService.Get(id);

            if (ExistingTask is null)
                return NotFound();  
            else
                TableTaskService.Delete(ExistingTask);
                return NoContent();
        }

    }
}

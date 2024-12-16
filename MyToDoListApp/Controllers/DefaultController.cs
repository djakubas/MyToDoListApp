using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace MyToDoListApp.Controllers
{
    [Route("/")]
    [Authorize]
    [ApiController]
    public class Controller : ControllerBase
    {

        private readonly ILogger<TasksController> _logger;
        public Controller(ILogger<TasksController> logger)
        {
            _logger = logger;
        }
        [EnableCors("CorsPolicyGitHub")]
        [Route("/{**}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [HttpGet]
        public IActionResult Get(string catchAll)
        {
            return BadRequest();
        }
        
    }
}

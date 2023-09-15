using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class JobController : ControllerBase
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok(true);
        }
    }
}

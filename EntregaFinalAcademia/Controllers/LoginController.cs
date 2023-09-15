using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class LoginController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok(true);
        }
    }
}

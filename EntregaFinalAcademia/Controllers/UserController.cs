using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class UserController : ControllerBase
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

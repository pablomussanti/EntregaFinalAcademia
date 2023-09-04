using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class ProyectController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

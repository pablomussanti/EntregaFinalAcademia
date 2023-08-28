using Microsoft.AspNetCore.Mvc;

namespace EntregaFinalAcademia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

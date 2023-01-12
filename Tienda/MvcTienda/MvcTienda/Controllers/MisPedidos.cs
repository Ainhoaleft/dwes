using Microsoft.AspNetCore.Mvc;

namespace MvcTienda.Controllers
{
    public class MisPedidos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

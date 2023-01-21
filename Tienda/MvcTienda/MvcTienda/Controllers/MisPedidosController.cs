using Microsoft.AspNetCore.Mvc;

namespace MvcTienda.Controllers
{
    public class MisPedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

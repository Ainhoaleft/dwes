using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTienda.Data;
using System.Data;

namespace MvcTienda.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisPedidosController : Controller
    {
        private readonly MvcTiendaContexto _context;

        public MisPedidosController(MvcTiendaContexto context)
        {
            _context = context;
        }


        // GET: MisPedidos
        public async Task<IActionResult> Index()
        {
            //var mvcTiendaContexto = _context.Pedidos.Include(p => p.Cliente).Include(p => p.Estado);
            //return View(await mvcTiendaContexto.ToListAsync());

            // Se selecciona el empleado correspondiente al usuario actual
            string emailCliente = User.Identity.Name;

            var cliente = await _context.Clientes.Where(e => e.Email == emailCliente)
            .FirstOrDefaultAsync();


            if (cliente == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // Se seleccionan los avisos del Empleado correspondiente al usuario actual
            var misPedidos = _context.Pedidos
            .Where(a => a.ClienteId == cliente.Id)
            .OrderByDescending(a => a.Fecha)
            .Include(a => a.Cliente)
            .Include(a => a.Detalles)
            .Include(a => a.Estado);
            return View(await misPedidos.ToListAsync());
            // var mvcSoporteContexto = _context.Avisos.Include(a => a.Empleado)
            // .Include(a => a.Equipo).Include(a => a.TipoAveria);
            // return View(await mvcSoporteContexto.ToListAsync());

        }

        // GET: MisPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                .ThenInclude(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
    }
}

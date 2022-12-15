using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTienda.Data;
using MvcTienda.Models;

namespace MvcTienda.Controllers
{
    public class Escaparate : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        private readonly MvcTiendaContexto _context;

        public Escaparate(MvcTiendaContexto context)
        {
            _context = context;
        }
        // POST: Escaparate/AgregarCarrito/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCarrito(int id)
        {
            // Cargar datos de producto a añadir al carrito
            var producto = await _context.Productos
            .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            // Crear nuevo pedido, si el carrito está vacío y, por tanto, no existe pedido actual
            // La variable de sesión NumPedido almacena el número de pedido del carrito
            //if (string.IsNullOrEmpty(HttpContext.Session.GetString("NumPedido")) )
            if (HttpContext.Session.GetString("NumPedido") == null)
            {
                // Crear objeto pedido a agregar
                Pedido pedido = new Pedido();
                pedido.Fecha = DateTime.Now;
                pedido.Confirmado = null;
                pedido.Preparado = null;
                pedido.Enviado = null;
                pedido.Cobrado = null;
                pedido.Devuelto = null;
                pedido.Anulado = null;
                pedido.ClienteId = 2; // Asignar el cliente correspondiente al usuario actual
                                      // Pruebas sobre el cliente Id=2
                pedido.EstadoId = 1; // Estado: "Pendiente" (Sin confirmar)
                if (ModelState.IsValid)
                {
                    _context.Add(pedido);
                    await _context.SaveChangesAsync();
                }
                // Se asigna el número de pedido a la variable de sesión
                // que almacena el número de pedido del carrito
                HttpContext.Session.SetString("NumPedido", pedido.Id.ToString());
            }
            // Crear objeto detalle para agregar el producto al detalle del pedido del carrito
            Detalle detalle = new Detalle();
            string strNumeroPedido = HttpContext.Session.GetString("NumPedido");
            detalle.PedidoId = Convert.ToInt32(strNumeroPedido);
            detalle.ProductoId = id; // El valor id tiene el id del producto a agregar
            detalle.Cantidad = 1;
            detalle.Precio = producto.Precio;
            detalle.Descuento = 0;
            if (ModelState.IsValid)
            {
                _context.Add(detalle);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

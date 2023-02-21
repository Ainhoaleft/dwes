﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTienda.Data;
using MvcTienda.Models;
using System.Data;

namespace MvcTienda.Controllers
{
    public class EscaparateController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        private readonly MvcTiendaContexto _context;

        public EscaparateController(MvcTiendaContexto context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var productos = _context.Productos.AsQueryable();

            if (id == null)
            {
                // Selecciona productos del escaparte
                productos = productos.Where(x => x.Escaparate == true);
            }
            else
            {
                // Selecciona productos del escaprate
                productos = productos.Where(x => x.CategoriaId == id);

                // Obtiene el nombre de la categoría selecionada
                ViewBag.DescriptionCategoria = _context.Categorias.Find(id).Descripcion.ToString();
            }

            ViewData["ListaCategorias"] = _context.Categorias.OrderBy(c => c.Descripcion).ToList();
            productos = productos.Include(a => a.Categoria);

            return View(await productos.ToListAsync());
        }

        // GET AnyadirCarrito
        // La acción GET mostrará los datos del producto a añadir
        public async Task<IActionResult> AnyadirCarrito(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
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
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnyadirCarrito(Producto producto)
        {
            // POST: Escaparate/AgregarCarrito/5
            // [HttpPost]
            // [ValidateAntiForgeryToken]

            // public async Task<ActionResult>AñadirCarrito(int id)
            // {
            // Cargar datos de producto a añadir al carrito
            // var producto = await_context.Productos
            // .FirstOrDefaultAsync(m=>m.Id == id);
            // if (producto == null)
            // {
            // return NotFound();
            // }

            // Crear objetos peido y detalle a agregar
            // Pedido pedido = new Pedido();
            // Detalle detalle = new Detalle();

            // Cliente usuario = await _context.Clientes.Where(p=>p.Email == User.Identity.Name).FirstOrDefaultAsync();

            // if(HttpContext.Sesion.GetString("NumPedido") == null;
            // {
            //  pedido.Fecha = DateTime.Now;
            // pedido.Confirmado = null;
            // pedido.Preparado = null;
            // pedido.Enviado = null;
            // pedido.Cobrado = null;
            // pedido.Devuelto = null;
            // pedido.Anulado = null;
            // pedido.ClienteId = usuario.Id;
            // pedido.EstadoId = 1;
            // if(ModelState.IsValid)
            // {
            // _context.Add(pedido);
            //  await _context.SaveChangesAsync();
            // }


            // HttpContext.Session.SetString("NumPedido", pedido.Id.ToString());
            //}

            // Agregar producto al detalle de un pedido existente
            // string strNumeroPedido = HttpContext.Session.GetString("NumPedido");
            // detalle.PedidoId = Convert.ToInt32(strNumeroPedido);

            // El valor de id tiene el Id del producto a agregar
            // detalle.ProductoId = id;
            // detalle.Cantidad = 1;
            // detalle.Precio = producto.Precio;
            // detalle.Descuento = 0;
            // if (ModelState.IsValid)
            // {
            // _context.Add(detalle);
            // await _context.SaveChangesAsync();
            // }
            // return RedirectToAction(nameof(Index));
            // } 
            // }


            string emailUsuario = User.Identity.Name;
            int ClienteId;
            Pedido pedidoActual;
            var pendiente = await _context.Estados
                .Where(e => e.Descripcion == "Pendiente")
                .FirstOrDefaultAsync();

            var cliente = await _context.Clientes
                .Where(e => e.Email == emailUsuario)
                .FirstOrDefaultAsync();

            if (cliente != null)
            {
                ClienteId = cliente.Id;

                pedidoActual = await _context.Pedidos
                    .Include(p => p.Detalles)
                    .Include(p => p.Cliente)
                    .Where(e => e.ClienteId == ClienteId && e.EstadoId == pendiente.Id)
                    .FirstOrDefaultAsync();

                if (pedidoActual != null)
                {
                    // Buscamos si ya existe una línea para el producto en el pedido actual
                    var lineaExistente = pedidoActual.Detalles.FirstOrDefault(d => d.ProductoId == producto.Id);
                    if (lineaExistente != null)
                    {
                        // Si ya existe una línea, incrementamos la cantidad
                        lineaExistente.Cantidad += 1;
                    }
                    else
                    {
                        // si hemos encontrado el pedido, añadimos una nueva línea al pedido.
                        Detalle detalle = new Detalle();
                        detalle.ProductoId = producto.Id;
                        detalle.Cantidad = 1;
                        detalle.Descuento = 0;
                        detalle.Precio = producto.Precio;
                        detalle.PedidoId = pedidoActual.Id;

                        pedidoActual.Detalles.Add(detalle);

                        _context.Detalles.Add(detalle);
                    }
                }
                else
                {
                    // en caso contrario, hay que crear el pedido y que este sea la primera línea.
                    pedidoActual = new Pedido();
                    pedidoActual.ClienteId = 1;
                    pedidoActual.Detalles = new List<Detalle>();
                    pedidoActual.EstadoId = 1;
                    pedidoActual.Fecha = DateTime.Now;

                    Detalle detalle = new Detalle();
                    detalle.ProductoId = producto.Id;
                    detalle.Cantidad = 1;
                    detalle.Descuento = 0;
                    detalle.Precio = producto.Precio;
                    detalle.PedidoId = pedidoActual.Id;

                    pedidoActual.Detalles.Add(detalle);

                    _context.Pedidos.Add(pedidoActual);
                }

            }

            return Ok();
        }
      
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Dummy(int? id)
        {
 
            string emailUsuario = User.Identity.Name;
            int ClienteId;
            Pedido pedidoActual;
            var pendiente = await _context.Estados
                .Where(e => e.Descripcion == "Pendiente")
                .FirstOrDefaultAsync();

            var cliente = await _context.Clientes
                .Where(e => e.Email == emailUsuario)
                .FirstOrDefaultAsync();

            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            if (cliente != null)
            {
                ClienteId = cliente.Id;

                pedidoActual = await _context.Pedidos
                    .Include(p => p.Detalles)
                    .Include(p => p.Cliente)
                    .Where(e => e.ClienteId == ClienteId && e.EstadoId == pendiente.Id)
                    .FirstOrDefaultAsync();

                if (pedidoActual != null)
                {
                    // Buscamos si ya existe una línea para el producto en el pedido actual
                    var lineaExistente = pedidoActual.Detalles.FirstOrDefault(d => d.ProductoId == producto.Id);
                    if (lineaExistente != null)
                    {
                        // Si ya existe una línea, incrementamos la cantidad
                        lineaExistente.Cantidad += 1;
                    }
                    else
                    {
                        // si hemos encontrado el pedido, añadimos una nueva línea al pedido.
                        Detalle detalle = new Detalle();
                        detalle.ProductoId = producto.Id;
                        detalle.Cantidad = 1;
                        detalle.Descuento = 0;
                        detalle.Precio = producto.Precio;
                        detalle.PedidoId = pedidoActual.Id;

                        pedidoActual.Detalles.Add(detalle);

                        _context.Detalles.Add(detalle);
                    }
                }
                else
                {
                    // en caso contrario, hay que crear el pedido y que este sea la primera línea.
                    pedidoActual = new Pedido();
                    pedidoActual.ClienteId = ClienteId;
                    pedidoActual.Detalles = new List<Detalle>();
                    pedidoActual.EstadoId = pendiente.Id;
                    pedidoActual.Fecha = DateTime.Now;

                    Detalle detalle = new Detalle();
                    detalle.ProductoId = producto.Id;
                    detalle.Cantidad = 1;
                    detalle.Descuento = 0;
                    detalle.Precio = producto.Precio;
                    detalle.PedidoId = pedidoActual.Id;

                    pedidoActual.Detalles.Add(detalle);

                    _context.Pedidos.Add(pedidoActual);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Escaparate");
        }
    }

}



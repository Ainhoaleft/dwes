﻿using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTienda.Data;
using MvcTienda.Models;

namespace MvcTienda.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductosController : Controller
    {
        private readonly MvcTiendaContexto _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductosController(MvcTiendaContexto context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string strCadenaBusqueda, int? pageNumber, int? categoriaId, int? categoriaIdActual, string busquedaActual)
        {

            if (strCadenaBusqueda != null)
            {
                pageNumber = 1;
            }
            else
            {
                strCadenaBusqueda = ViewData["strCadenaBusqueda"] as string;
            }
            var productos = _context.Productos.AsQueryable();

            productos = productos.OrderBy(x => x.Descripcion);

            if (!String.IsNullOrEmpty(strCadenaBusqueda))
            {
                productos = productos.Where(s => s.Descripcion.Contains(strCadenaBusqueda));
            }

            productos = productos.Include(a => a.Categoria)
                                   .Include(a => a.Detalles);


            ViewData["BusquedaActual"] = strCadenaBusqueda;
            int pageSize = 5;
            return View(await PaginatedList<Producto>.CreateAsync(productos.AsNoTracking(),
            pageNumber ?? 1, pageSize));

            var mvcTiendaContexto = _context.Productos.Include(p => p.Categoria);
            return View(await mvcTiendaContexto.ToListAsync());

            return View(await productos.AsNoTracking().ToListAsync());

        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
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

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Texto,Precio,PrecioCadena,Stock,Escaparate,Imagen,CategoriaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
                //.Include(e => e.Pedidos)
                //.ThenInclude(a => a.Cantidad)
                //.Include(e => e.Categoria)
               // .ThenInclude(a => a.Descripcion)
               //.FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Texto,Precio,PrecioCadena,Stock,Escaparate,Imagen,CategoriaId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
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

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'MvcTiendaContexto.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
        // GET: Productos/CambiarImagen/5
        public async Task<IActionResult> CambiarImagen(int? id)
        {
            if (id == null || _context.Productos == null)
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
        //POST: Productos/CambiarImagen/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarImagen(int? id, IFormFile imagen)
        {
            if (id == null)
            {
                return NotFound();

            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            if (imagen == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // Copiar archivo de imagen
                string strRutaImagenes = Path.Combine(_webHostEnvironment.WebRootPath, "imagenes");
                string strExtension = Path.GetExtension(imagen.FileName);
                string strNombreFichero = producto.Id.ToString() + strExtension;
                string strRutaFichero = Path.Combine(strRutaImagenes, strNombreFichero);

                using (var fileStream = new FileStream(strRutaFichero, FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }
                // Actualizar producto con nueva imagen
                producto.Imagen = strNombreFichero;
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(producto);
        }
    }
}
    
    


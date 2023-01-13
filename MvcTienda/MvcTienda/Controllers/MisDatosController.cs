﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTienda.Data;
using MvcTienda.Models;
using System.Data;

namespace MvcTienda.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisDatosController : Controller
    {
        private readonly MvcTiendaContexto _context;
        public MisDatosController(MvcTiendaContexto context)
        {
            _context = context;
        }
        // GET: MisDatos/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: MisDatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create([Bind("Id,Nombre,Email,Telefono,FechaNacimiento")] Cliente cliente)
        {
            // Asignar el Email del usuario actuals
            cliente.Email = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }
        // GET: MisDatos/Edit
        public async Task<IActionResult> Edit()
        {
            // Se seleccionan los datos del empleado correspondiente al usuario actual
            string? emailUsuario = User.Identity.Name;
            Cliente? cliente = await _context.Clientes
            .Where(e => e.Email == emailUsuario)
            .FirstOrDefaultAsync();
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        // POST: MisDatos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
        [Bind("Id,Nombre,Email,Telefono,FechaNacimiento")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }
        private bool EmpleadoExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }  
}

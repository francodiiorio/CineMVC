using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineXperience.DataBase;
using CineXperience.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CineXperience.Controllers
{
    [Authorize]
    public class EntradasController : Controller
    {
        private readonly CineXperienceContext _context;

        public EntradasController(CineXperienceContext context)
        {
            _context = context;
        }

        // GET: Entradas
        public async Task<IActionResult> Index()
        {
            var cineXperienceContext = _context.Entradas.Include(e => e.Cliente).Include(e => e.Funcion);
            return View(await cineXperienceContext.ToListAsync());
        }
        public async Task<IActionResult> IndexCliente()
        {
            int currentId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var entradas = _context.Entradas.Include(e => e.Funcion).Include(e => e.Funcion.Pelicula).Include(e => e.Cliente).Where(e => e.ClienteId == currentId);

            return View(await entradas.ToListAsync());
        }

        // GET: Entradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.Cliente)
                .Include(e => e.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entradas/Create
        public IActionResult Create(int funcionId)
        {           
            TempData["funcionId"] = funcionId;           
            return View();
        }

        // POST: Entradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionId,CantAsientos,ClienteId")] Entrada model)
        {
            if (ModelState.IsValid)
            {
                int funcionId = (int)TempData["funcionId"];
                int clienteId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                model.ClienteId = clienteId;
                model.FuncionId = funcionId;
                Funcion funcion = _context.Funcion.FirstOrDefault(f => f.Id == funcionId);
                Cliente cliente = _context.Clientes.FirstOrDefault(u => u.Id == clienteId);

                int cantidadActual = 0;
                foreach(var m in funcion.movimientos)
                {
                    cantidadActual += m.CantAsientos;
                }
                if (cantidadActual + model.CantAsientos > funcion.Sala.Capacidad)
                {
                    ModelState.AddModelError("CantAsientos", "La cantidad de asientos seleccionada no está disponible.");
                    return View(model);
                }
                cliente.Movimientos ??= new List<Entrada>();
                cliente.Movimientos.Add(model);
                funcion.movimientos ??= new List<Entrada>();
                funcion.movimientos.Add(model);

                _context.Add(model);              
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        // GET: Entradas/Edit/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Discriminator", entrada.ClienteId);
            ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Id", entrada.FuncionId);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionId,CantAsientos,ClienteId")] Entrada entrada)
        {
            if (id != entrada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", entrada.ClienteId);
            ViewData["FuncionId"] = new SelectList(_context.Funcion, "Id", "Id", entrada.FuncionId);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.Cliente)
                .Include(e => e.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entradas == null)
            {
                return Problem("Entity set 'CineXperienceContext.Entradas'  is null.");
            }
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada != null)
            {
                _context.Entradas.Remove(entrada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
          return _context.Entradas.Any(e => e.Id == id);
        }
    }
}

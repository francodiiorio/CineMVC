﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineXperience.DataBase;
using CineXperience.Models;
using Microsoft.AspNetCore.Authorization;

namespace CineXperience.Controllers
{
    public class FuncionesController : Controller
    {
        private readonly CineXperienceContext _context;

        public FuncionesController(CineXperienceContext context)
        {
            _context = context;
        }

        // GET: Funciones
        [Authorize(Roles ="Admin, Empleados")]
        public async Task<IActionResult> Index()
        {
            var cineXperienceContext = _context.Funcion.Include(f => f.Pelicula).Include(f => f.Sala);
            return View(await cineXperienceContext.ToListAsync());
        }

        public async Task<IActionResult> IndexByMovie(int peliculaId)
        {
            var funciones = _context.Funcion.Include(f => f.Sala).Include(f => f.Pelicula).Where(f => f.PeliculaId == peliculaId);

            return View(await funciones.ToListAsync());
        }
        // GET: Funciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcion == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        [Authorize(Roles ="Admin, Empleado")]
        // GET: Funciones/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "Id", "Nombre");
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id");
            return View();
        }

        // POST: Funciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalaId,PeliculaId,Fecha,Hora,Precio")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                bool funcionExistente = _context.Funcion.Any(f =>
                    f.SalaId == funcion.SalaId &&
                    f.Fecha == funcion.Fecha &&
                    f.Hora == funcion.Hora);

                if (funcionExistente)
                {
                    ModelState.AddModelError(String.Empty, "Ya existe una función con la misma sala, fecha y hora.");
                    ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "Id", "Nombre", funcion.PeliculaId);
                    ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
                    return View(funcion);
                }

                _context.Add(funcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "Id", "Nombre", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Edit/5
        [Authorize(Roles = "Admin, Empleado")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcion == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion.FindAsync(id);
            if (funcion == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "Id", "Nombre", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // POST: Funciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalaId,PeliculaId,Fecha,Hora,Precio")] Funcion funcion)
        {
            if (id != funcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionExists(funcion.Id))
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
            ViewData["PeliculaId"] = new SelectList(_context.Pelicula, "Id", "Nombre", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Delete/5
        [Authorize(Roles = "Admin, Empleado")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcion == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // POST: Funciones/Delete/5
        [Authorize(Roles = "Admin, Empleado")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcion == null)
            {
                return Problem("Entity set 'CineXperienceContext.Funcion'  is null.");
            }
            var funcion = await _context.Funcion.FindAsync(id);
            if (funcion != null)
            {
                _context.Funcion.Remove(funcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionExists(int id)
        {
          return _context.Funcion.Any(e => e.Id == id);
        }

       
    }
}

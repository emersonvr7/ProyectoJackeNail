using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoJackeNail.Models;

namespace ProyectoJackeNail.Controllers
{
    public class AgendamientosController : Controller
    {
        private readonly TrabajoFinalContext _context;

        public AgendamientosController(TrabajoFinalContext context)
        {
            _context = context;
        }

        // GET: Agendamientos
        public async Task<IActionResult> Index()
        {
            var trabajoFinalContext = _context.Agendamientos.Include(a => a.Cliente).Include(a => a.Empleado).Include(a => a.Servicio);
            return View(await trabajoFinalContext.ToListAsync());
        }

        // GET: Agendamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamiento = await _context.Agendamientos
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamiento == null)
            {
                return NotFound();
            }

            return View(agendamiento);
        }

        // GET: Agendamientos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id");
            ViewData["ServicioId"] = new SelectList(_context.Services, "Id", "Id");
            return View();
        }

        // POST: Agendamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ServicioId,EmpleadoId,FechaAgenda,EstadoAgenda")] Agendamiento agendamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", agendamiento.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", agendamiento.EmpleadoId);
            ViewData["ServicioId"] = new SelectList(_context.Services, "Id", "Id", agendamiento.ServicioId);
            return View(agendamiento);
        }

        // GET: Agendamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamiento = await _context.Agendamientos.FindAsync(id);
            if (agendamiento == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", agendamiento.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", agendamiento.EmpleadoId);
            ViewData["ServicioId"] = new SelectList(_context.Services, "Id", "Id", agendamiento.ServicioId);
            return View(agendamiento);
        }

        // POST: Agendamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ServicioId,EmpleadoId,FechaAgenda,EstadoAgenda")] Agendamiento agendamiento)
        {
            if (id != agendamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamientoExists(agendamiento.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", agendamiento.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Id", agendamiento.EmpleadoId);
            ViewData["ServicioId"] = new SelectList(_context.Services, "Id", "Id", agendamiento.ServicioId);
            return View(agendamiento);
        }

        // GET: Agendamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamiento = await _context.Agendamientos
                .Include(a => a.Cliente)
                .Include(a => a.Empleado)
                .Include(a => a.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamiento == null)
            {
                return NotFound();
            }

            return View(agendamiento);
        }

        // POST: Agendamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamiento = await _context.Agendamientos.FindAsync(id);
            if (agendamiento != null)
            {
                _context.Agendamientos.Remove(agendamiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamientoExists(int id)
        {
            return _context.Agendamientos.Any(e => e.Id == id);
        }
    }
}

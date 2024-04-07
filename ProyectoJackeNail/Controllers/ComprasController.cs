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
    public class ComprasController : Controller
    {
        private readonly TrabajoFinalContext _context;

        public ComprasController(TrabajoFinalContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var comprasConDetalle = await _context.Compras
                                                .Include(c => c.DetalleCompras)
                                                .ToListAsync();
            return View(comprasConDetalle);
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            var proveedores = _context.Proveedors.ToList();
            ViewBag.Proveedors = proveedores;
            return View();
        }

        public class CompraData
        {
            public string[] arrayImagenInsumo { get; set; }
            public string[] arrayNombreInsumo { get; set; }
            public int[] arrayCantidadInsumo { get; set; }
            public int[] arrayUsosDisponibles { get; set; }
            public decimal[] arrayPrecioUnitario { get; set; }
            public string[] arrayCategoria { get; set; }
            public int[] arrayIdProveedor { get; set; }
            public decimal variDescuentoCompra { get; set; }
            public string variEstadoCompra { get; set; }
            public DateTime variFechaCompra { get; set; }
            public decimal variIvaCompra { get; set; }
            public decimal variSubtotalCompra { get; set; }
            public decimal variTotalValorInsumos { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompraData datos)
        {
            try
            {
                Compra compra = new Compra
                {
                    FechaCompra = datos.variFechaCompra,
                    DescuentoCompra = datos.variDescuentoCompra,
                    IvaCompra = datos.variIvaCompra,
                    SubtotalCompra = datos.variSubtotalCompra,
                    EstadoCompra = datos.variEstadoCompra
                };

                _context.Compras.Add(compra);
                await _context.SaveChangesAsync();

                for (int i = 0; i < datos.arrayNombreInsumo.Length; i++)
                {
                    DetalleCompra detalleCompra = new DetalleCompra
                    {
                        IdCompra = compra.IdCompra,
                        IdProveedor = datos.arrayIdProveedor[i],
                        NombreInsumo = datos.arrayNombreInsumo[i],
                        ImagenInsumo = datos.arrayImagenInsumo[i],
                        CantidadInsumo = datos.arrayCantidadInsumo[i],
                        UsosDisponibles = datos.arrayUsosDisponibles[i],
                        PrecioUnitario = datos.arrayPrecioUnitario[i],
                        Categoria = datos.arrayCategoria[i],
                        TotalValorInsumos = datos.variTotalValorInsumos
                    };

                    _context.DetalleCompras.Add(detalleCompra);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest("Error al procesar la solicitud: " + ex.Message);
            }
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,FechaCompra,DescuentoCompra,SubtotalCompra,IvaCompra,EstadoCompra")] Compra compra)
        {
            if (id != compra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.IdCompra))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.IdCompra == id);
        }
    }
}

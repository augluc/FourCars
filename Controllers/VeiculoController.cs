﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FourCars.Data;
using FourCars.Models;
using Microsoft.AspNetCore.Authorization;

namespace FourCars.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veiculo

        public async Task<IActionResult> Index(string modeloBusca, Categoria? categoriaBusca)
        {
            return View("Index", await _context.Veiculo.Where(v => (v.Modelo.Contains(modeloBusca) || modeloBusca == null) && (v.Categoria == categoriaBusca || categoriaBusca == null)).ToListAsync());
        }

        // GET: Veiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.VeiculoId == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculo/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("VeiculoId,Categoria,Valor,Ano,Modelo,Marca")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("VeiculoId,Categoria,Valor,Ano,Modelo,Marca")] Veiculo veiculo)
        {
            if (id != veiculo.VeiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.VeiculoId))
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
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.VeiculoId == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculo.Any(e => e.VeiculoId == id);
        }
    }
}

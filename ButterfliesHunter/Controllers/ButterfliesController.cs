﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ButterfliesHunter.Models;
using System.Diagnostics;

namespace ButterfliesHunter.Controllers
{
    public class ButterfliesController : Controller
    {
        private readonly AppDbContext _context;

        public ButterfliesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Butterflies
        public IActionResult Index(int? id, int? author)
        {
            Debug.WriteLine("-------------------------->" + author + "<");
    
            switch (id ?? 0)
            {
                case 0: // default order by Ranking, reverse
                    return View(_context.Butterflies.ToList());
                case 1:
                    return View(_context.Butterflies.ToList().OrderBy(b => b.Name));
                case 2:
                    return View(_context.Butterflies.ToList().OrderBy(b => b.AuthorId));
                case 3:
                    return View(_context.Butterflies.ToList().FindAll(b => b.IsProtected).OrderBy(b => b.Ranking).Reverse());
                case 4:
                    return View(_context.Butterflies.ToList().FindAll(b => b.IsProtected).OrderBy(b => b.Ranking).Reverse());
                case 5:
                    return View(_context.Butterflies.ToList().FindAll(b => b.IsProtected).OrderBy(b => b.Ranking).Reverse());
                default:
                    return View(_context.Butterflies.ToList());
            }
        }

        // GET: Butterflies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butterfly = await _context.Butterflies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (butterfly == null)
            {
                return NotFound();
            }

            return View(butterfly);
        }

        // GET: Butterflies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Butterflies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Range,Ranking,IsProtected,AuthorId,Description")] Butterfly butterfly)
        {
            if (ModelState.IsValid)
            {
                _context.Add(butterfly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(butterfly);
        }

        // GET: Butterflies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butterfly = await _context.Butterflies.FindAsync(id);
            if (butterfly == null)
            {
                return NotFound();
            }
            return View(butterfly);
        }

        // POST: Butterflies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Range,Ranking,IsProtected,AuthorId,Description")] Butterfly butterfly)
        {
            if (id != butterfly.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(butterfly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButterflyExists(butterfly.Id))
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
            return View(butterfly);
        }

        // GET: Butterflies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butterfly = await _context.Butterflies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (butterfly == null)
            {
                return NotFound();
            }

            return View(butterfly);
        }

        // POST: Butterflies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var butterfly = await _context.Butterflies.FindAsync(id);
            _context.Butterflies.Remove(butterfly);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ButterflyExists(int id)
        {
            return _context.Butterflies.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ButterfliesHunter.Models;
using Microsoft.AspNetCore.Authorization;

namespace ButterfliesHunter.Controllers
{
    [Authorize]
    public class HuntersController : Controller
    {
        private readonly AppDbContext _context;

        public HuntersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hunters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hunters.ToListAsync());
        }

        // GET: Hunters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunter = await _context.Hunters
                .FirstOrDefaultAsync(m => m.HunterId == id);
            if (hunter == null)
            {
                return NotFound();
            }

            return View(hunter);
        }

        // GET: Hunters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hunters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HunterId,Name,Email,Voted,Display")] Hunter hunter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hunter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hunter);
        }

        // GET: Hunters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunter = await _context.Hunters.FindAsync(id);
            if (hunter == null)
            {
                return NotFound();
            }
            return View(hunter);
        }

        // POST: Hunters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HunterId,Name,Email,Voted,Display")] Hunter hunter)
        {
            if (id != hunter.HunterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hunter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HunterExists(hunter.HunterId))
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
            return View(hunter);
        }

        // GET: Hunters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hunter = await _context.Hunters
                .FirstOrDefaultAsync(m => m.HunterId == id);
            if (hunter == null)
            {
                return NotFound();
            }

            return View(hunter);
        }

        // POST: Hunters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hunter = await _context.Hunters.FindAsync(id);
            _context.Hunters.Remove(hunter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HunterExists(int id)
        {
            return _context.Hunters.Any(e => e.HunterId == id);
        }
    }
}

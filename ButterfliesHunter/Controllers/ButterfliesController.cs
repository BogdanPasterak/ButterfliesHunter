using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ButterfliesHunter.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace ButterfliesHunter.Controllers
{
    public class ButterfliesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _manager;


        public ButterfliesController(AppDbContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Butterflies
        public IActionResult Index(int? id, string author, bool? protect)
        {
            // id chooses the view method
            switch (id ?? 0)
            {
                case 0: // default order by Ranking, reverse
                    return View(_context.Butterflies.ToList().OrderBy(b => b.Ranking).Reverse());
                case 1: // order by Name
                    return View(_context.Butterflies.ToList().OrderBy(b => b.Name));
                case 2: // order by Author
                    return View(_context.Butterflies.ToList().OrderBy(b => b.Ranking).Reverse()
                                .OrderBy(b => b.AuthorId));
                case 3: // filter butterflies by protect or not
                    return View(_context.Butterflies.ToList()
                                .FindAll(b => b.IsProtected == (protect ?? true))
                                .OrderBy(b => b.Ranking).Reverse());
                case 4:// showing only those who I am an author ( email of the logged in person ) 
                    Hunter hunter = _context.Hunters.FirstOrDefault(h => h.Email == author);
                    if (hunter == null )
                    {
                        return View(new List<Butterfly>());
                    }
                    else
                    {
                        return View(_context.Butterflies.ToList()
                                    .FindAll(b => b.AuthorId == hunter.HunterId)
                                    .OrderBy(b => b.Ranking).Reverse());
                    }
                case 5: // top 10
                    return View(_context.Butterflies.ToList().OrderBy(b => b.Ranking).Reverse().Take(10));
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Butterflies/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Range,Ranking,IsProtected,AuthorId,Description,ImgURL")]Butterfly butterfly)
        {

            if (!IsImageUrl( butterfly.ImgURL))
            {
                butterfly.ImgURL = "/img/img00.jpg";
            }
            string email = _manager.GetUserName(User);
            butterfly.AuthorId = _context.Hunters.FirstOrDefault(h => h.Email == email).HunterId;


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
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,Range,Ranking,IsProtected,AuthorId,Description,ImgURL")] Butterfly butterfly)
        {

            Debug.WriteLine("--------------------------Edit--Post--->" + id + "<---");
            //if (id != butterfly.Id)
            //{
            //    return NotFound();
            //}
            butterfly.Id = id;

            if (!IsImageUrl(butterfly.ImgURL))
            {
                Debug.WriteLine("--------------------------URL--Post--->" + butterfly.ImgURL + "<---");
                butterfly.ImgURL = "/img/img00.jpg";
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

        private bool IsImageUrl(string URL)
        {
            try
            {
                if (URL.StartsWith("/img/img"))
                {
                    return true;
                }
                var req = (HttpWebRequest)HttpWebRequest.Create(URL);
                req.Method = "HEAD";
                using (var resp = req.GetResponse())
                {
                    return resp.ContentType.ToLower(CultureInfo.InvariantCulture)
                               .StartsWith("image/");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

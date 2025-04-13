using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOROMOTORS.Data;
using BOROMOTORS.Models;

namespace BOROMOTORS.Controllers
{
    public class DirtBikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirtBikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DirtBikesz
        public async Task<IActionResult> Index(string searchString, string sortOrder, int? minPrice, int? maxPrice, string manufacturer, string category)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["PriceSortParm"] = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            var query = _context.DirtBikes.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                string lower = searchString.ToLower();
                query = query.Where(b => b.Model.ToLower().Contains(lower) || b.Manufacturer.ToLower().Contains(lower));
            }

            if (!string.IsNullOrEmpty(manufacturer))
            {
                query = query.Where(b => b.Manufacturer == manufacturer);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(b => b.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(b => b.Price <= maxPrice.Value);
            }

            switch (sortOrder)
            {
                case "price_desc":
                    query = query.OrderByDescending(b => b.Price);
                    break;
                case "price_asc":
                    query = query.OrderBy(b => b.Price);
                    break;
            }
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(b => b.Category == category); // увери се, че имаш такова property
            }


            // За dropdown-а: взимаме различните марки от базата
            ViewBag.Manufacturers = await _context.DirtBikes.Select(b => b.Manufacturer).Distinct().ToListAsync();

            return View(await query.ToListAsync());
        }


        // GET: DirtBikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtBike == null)
            {
                return NotFound();
            }

            return View(dirtBike);
        }

        // GET: DirtBikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirtBikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Manufacturer,Price,Stock,Description,ImageUrl,VideoUrl,TopSpeed,Horsepower,Weight")] DirtBike dirtBike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dirtBike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dirtBike);
        }

        // GET: DirtBikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes.FindAsync(id);
            if (dirtBike == null)
            {
                return NotFound();
            }
            return View(dirtBike);
        }

        // POST: DirtBikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Model,Manufacturer,Price,Stock,Description,ImageUrl,VideoUrl,TopSpeed,Horsepower,Weight")] DirtBike dirtBike)
        {
            if (id != dirtBike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dirtBike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirtBikeExists(dirtBike.Id))
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
            return View(dirtBike);
        }

        // GET: DirtBikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtBike == null)
            {
                return NotFound();
            }

            return View(dirtBike);
        }

        // POST: DirtBikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var dirtBike = await _context.DirtBikes.FindAsync(id);
            if (dirtBike != null)
            {
                _context.DirtBikes.Remove(dirtBike);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirtBikeExists(int? id)
        {
            return _context.DirtBikes.Any(e => e.Id == id);
        }
    }
}

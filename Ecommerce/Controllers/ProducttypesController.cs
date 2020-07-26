using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class ProducttypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProducttypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Producttypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producttype.ToListAsync());
        }

        // GET: Producttypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttypes = await _context.Producttype
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producttypes == null)
            {
                return NotFound();
            }

            return View(producttypes);
        }

        // GET: Producttypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producttypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Producttype")] Producttypes producttypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producttypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producttypes);
        }

        // GET: Producttypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttypes = await _context.Producttype.FindAsync(id);
            if (producttypes == null)
            {
                return NotFound();
            }
            return View(producttypes);
        }

        // POST: Producttypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Producttype")] Producttypes producttypes)
        {
            if (id != producttypes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producttypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducttypesExists(producttypes.ID))
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
            return View(producttypes);
        }

        // GET: Producttypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producttypes = await _context.Producttype
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producttypes == null)
            {
                return NotFound();
            }

            return View(producttypes);
        }

        // POST: Producttypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producttypes = await _context.Producttype.FindAsync(id);
            _context.Producttype.Remove(producttypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducttypesExists(int id)
        {
            return _context.Producttype.Any(e => e.ID == id);
        }
    }
}

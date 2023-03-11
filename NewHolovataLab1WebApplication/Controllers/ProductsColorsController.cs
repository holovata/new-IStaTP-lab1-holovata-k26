using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewHolovataLab1WebApplication.Models;

namespace NewHolovataLab1WebApplication.Controllers
{
    public class ProductsColorsController : Controller
    {
        private readonly DblibraryLab1Context _context;

        public ProductsColorsController(DblibraryLab1Context context)
        {
            _context = context;
        }

        // GET: ProductsColors
        public async Task<IActionResult> Index()
        {
            var dblibraryLab1Context = _context.ProductsColors.Include(p => p.Color).Include(p => p.Product);
            return View(await dblibraryLab1Context.ToListAsync());
        }

        // GET: ProductsColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductsColors == null)
            {
                return NotFound();
            }

            var productsColor = await _context.ProductsColors
                .Include(p => p.Color)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsColor == null)
            {
                return NotFound();
            }

            return View(productsColor);
        }

        // GET: ProductsColors/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductsColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,ColorId,Availability")] ProductsColor productsColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", productsColor.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productsColor.ProductId);
            return View(productsColor);
        }

        // GET: ProductsColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductsColors == null)
            {
                return NotFound();
            }

            var productsColor = await _context.ProductsColors.FindAsync(id);
            if (productsColor == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", productsColor.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productsColor.ProductId);
            return View(productsColor);
        }

        // POST: ProductsColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,ColorId,Availability")] ProductsColor productsColor)
        {
            if (id != productsColor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsColorExists(productsColor.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", productsColor.ColorId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productsColor.ProductId);
            return View(productsColor);
        }

        // GET: ProductsColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductsColors == null)
            {
                return NotFound();
            }

            var productsColor = await _context.ProductsColors
                .Include(p => p.Color)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsColor == null)
            {
                return NotFound();
            }

            return View(productsColor);
        }

        // POST: ProductsColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductsColors == null)
            {
                return Problem("Entity set 'DblibraryLab1Context.ProductsColors'  is null.");
            }
            var productsColor = await _context.ProductsColors.FindAsync(id);
            if (productsColor != null)
            {
                _context.ProductsColors.Remove(productsColor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsColorExists(int id)
        {
          return _context.ProductsColors.Any(e => e.Id == id);
        }
    }
}

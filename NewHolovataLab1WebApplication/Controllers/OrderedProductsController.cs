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
    public class OrderedProductsController : Controller
    {
        private readonly DblibraryLab1Context _context;

        public OrderedProductsController(DblibraryLab1Context context)
        {
            _context = context;
        }

        // GET: OrderedProducts
        public async Task<IActionResult> Index()
        {
            var dblibraryLab1Context = _context.OrderedProducts.Include(o => o.Color).Include(o => o.Order).Include(o => o.Product);
            return View(await dblibraryLab1Context.ToListAsync());
        }

        // GET: OrderedProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderedProducts == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProducts
                .Include(o => o.Color)
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            return View(orderedProduct);
        }

        // GET: OrderedProducts/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: OrderedProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,OrderId,Amount,ColorId")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderedProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", orderedProduct.ColorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderedProduct.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderedProducts == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProducts.FindAsync(id);
            if (orderedProduct == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", orderedProduct.ColorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderedProduct.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,OrderId,Amount,ColorId")] OrderedProduct orderedProduct)
        {
            if (id != orderedProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderedProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderedProductExists(orderedProduct.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", orderedProduct.ColorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderedProduct.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", orderedProduct.ProductId);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderedProducts == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProducts
                .Include(o => o.Color)
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            return View(orderedProduct);
        }

        // POST: OrderedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderedProducts == null)
            {
                return Problem("Entity set 'DblibraryLab1Context.OrderedProducts'  is null.");
            }
            var orderedProduct = await _context.OrderedProducts.FindAsync(id);
            if (orderedProduct != null)
            {
                _context.OrderedProducts.Remove(orderedProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderedProductExists(int id)
        {
          return _context.OrderedProducts.Any(e => e.Id == id);
        }
    }
}

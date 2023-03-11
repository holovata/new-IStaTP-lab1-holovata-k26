using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewHolovataLab1WebApplication.Models;

namespace NewHolovataLab1WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DblibraryLab1Context _context;

        public OrdersController(DblibraryLab1Context context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(int? id, string? email, string? name, string? lastName, string? address)
        {
            //var dblibraryLab1Context = _context.Orders.Include(o => o.Shop).Include(o => o.User);
            //return View(await dblibraryLab1Context.ToListAsync());

            if (id == null) return RedirectToAction("Index", "Users");
            //finding orders by user
            ViewBag.UserId = id;
            ViewBag.UserEmail = email;
            ViewBag.UserName = name;
            ViewBag.UserLastName = lastName;
            ViewBag.UserAddress = address;
            var ordersByUser = _context.Orders.Where(o => o.UserId == id).Include(o => o.User);

            return View(await ordersByUser.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Shop)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create(int userId)
        {
            //ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            //return View();
            ViewBag.UserId = userId;
            ViewBag.UserEmail = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Email;
            ViewBag.UserName = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Name;
            ViewBag.UserLastName = _context.Users.Where(u => u.Id == userId).FirstOrDefault().LastName;
            ViewBag.UserAddress = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Address;

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int userId, [Bind("Id,UserId,ShopId,Time")] Order order)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(order);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", order.ShopId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            //return View(order);

            order.UserId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Orders", new
                {
                    id = userId,
                    email = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Email,
                    name = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Name,
                    lastName = _context.Users.Where(u => u.Id == userId).FirstOrDefault().LastName,
                    address = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Address
                });
            }
            return RedirectToAction("Index", "Orders", new
            {
                id = userId,
                email = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Email,
                name = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Name,
                lastName = _context.Users.Where(u => u.Id == userId).FirstOrDefault().LastName,
                address = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Address
            });
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", order.ShopId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ShopId,Time")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", order.ShopId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Shop)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'DblibraryLab1Context.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.Id == id);
        }
    }
}

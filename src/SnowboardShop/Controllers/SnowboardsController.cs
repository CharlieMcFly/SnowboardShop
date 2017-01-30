using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data;
using SnowboardShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace SnowboardShop.Controllers
{
    [Authorize]
    public class SnowboardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SnowboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Snowboards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Snowboard.ToListAsync());
        }

        // GET: Snowboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboard
                .SingleOrDefaultAsync(m => m.ID == id);
            if (snowboard == null)
            {
                return NotFound();
            }

            return View(snowboard);
        }

        // GET: Snowboards/Create
        [Authorize(Roles = "Manager, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Snowboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,marque,height,camber,flex,shape,price,urlPhoto")] Snowboard snowboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snowboard);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(snowboard);
        }

        // GET: Snowboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboard.SingleOrDefaultAsync(m => m.ID == id);
            if (snowboard == null)
            {
                return NotFound();
            }
            return View(snowboard);
        }

        // POST: Snowboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,marque,height,camber,flex,shape,price,urlPhoto")] Snowboard snowboard)
        {
            if (id != snowboard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snowboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnowboardExists(snowboard.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(snowboard);
        }

        // GET: Snowboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboard
                .SingleOrDefaultAsync(m => m.ID == id);
            if (snowboard == null)
            {
                return NotFound();
            }

            return View(snowboard);
        }

        // POST: Snowboards/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snowboard = await _context.Snowboard.SingleOrDefaultAsync(m => m.ID == id);
            _context.Snowboard.Remove(snowboard);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize (Roles ="User")]
        public IActionResult AddSnowboard(string id)
        {
            ShoppingCart panier = SessionExtensions.GetObjectFromJson<ShoppingCart>(HttpContext.Session, "panier");
            panier.addSnowboard(id);
            Console.WriteLine(id);
            SessionExtensions.SetObjectAsJson(HttpContext.Session, "panier", panier);

            return RedirectToAction("Index");
        }

        private bool SnowboardExists(int id)
        {
            return _context.Snowboard.Any(e => e.ID == id);
        }
    }
}

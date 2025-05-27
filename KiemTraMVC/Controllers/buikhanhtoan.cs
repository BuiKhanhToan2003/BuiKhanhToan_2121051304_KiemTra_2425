using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiemTraMVC.Data;
using KiemTraMVC.Models;

namespace KiemTraMVC.Controllers
{
    public class buikhanhtoanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public buikhanhtoanController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.buikhanhtoan.ToListAsync());
        }


        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buikhanhtoan = await _context.buikhanhtoan
                .FirstOrDefaultAsync(m => m.FullName == id);
            if (buikhanhtoan == null)
            {
                return NotFound();
            }

            return View(buikhanhtoan);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Address,Age")] buikhanhtoan buikhanhtoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buikhanhtoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buikhanhtoan);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buikhanhtoan = await _context.buikhanhtoan.FindAsync(id);
            if (buikhanhtoan == null)
            {
                return NotFound();
            }
            return View(buikhanhtoan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,Address,Age")] buikhanhtoan buikhanhtoan)
        {
            if (id != buikhanhtoan.FullName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buikhanhtoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!buikhanhtoanExists(buikhanhtoan.FullName))
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
            return View(buikhanhtoan);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buikhanhtoan = await _context.buikhanhtoan
                .FirstOrDefaultAsync(m => m.FullName == id);
            if (buikhanhtoan == null)
            {
                return NotFound();
            }

            return View(buikhanhtoan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var buikhanhtoan = await _context.buikhanhtoan.FindAsync(id);
            if (buikhanhtoan != null)
            {
                _context.buikhanhtoan.Remove(buikhanhtoan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool buikhanhtoanExists(string id)
        {
            return _context.buikhanhtoan.Any(e => e.FullName == id);
        }
    }
}

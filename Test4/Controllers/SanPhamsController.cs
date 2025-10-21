using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test4.Models;

namespace Test4.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly CFContext _context;

        public SanPhamsController(CFContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            var cFContext = _context.SanPhams.Include(s => s.Loai_San_Pham);
            return View(await cFContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.Loai_San_Pham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "Id");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,LoaiSanPhamId")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("ai cha cha");
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "Id", sanPham.LoaiSanPhamId);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "Id", sanPham.LoaiSanPhamId);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,LoaiSanPhamId")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
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
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "Id", sanPham.LoaiSanPhamId);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.Loai_San_Pham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(long id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}

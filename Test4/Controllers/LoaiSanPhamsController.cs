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
    public class LoaiSanPhamsController : Controller
    {
        private readonly CFContext _context;

        public LoaiSanPhamsController(CFContext context)
        {
            _context = context;
        }

        // GET: LoaiSanPhams
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSanPhams.ToListAsync());
        }

        // GET: LoaiSanPhams/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLoai,TenLoai,TrangThai")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }
            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,MaLoai,TenLoai,TrangThai")] LoaiSanPham loaiSanPham)
        {
            if (id != loaiSanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSanPhamExists(loaiSanPham.Id))
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
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var loaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham != null)
            {
                _context.LoaiSanPhams.Remove(loaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSanPhamExists(long id)
        {
            return _context.LoaiSanPhams.Any(e => e.Id == id);
        }
    }
}

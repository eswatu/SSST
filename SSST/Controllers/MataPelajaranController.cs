using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSST.Data;
using SSST.Models;

namespace SSST.Controllers
{
    public class MataPelajaranController : Controller
    {
        private readonly SSSTContext _context;

        public MataPelajaranController(SSSTContext context)
        {
            _context = context;
        }

        // GET: MataPelajaran
        public async Task<IActionResult> Index()
        {
            var sSSTContext = _context.MataPelajaran.Include(m => m.Guru).Include(m => m.Kelas);
            return View(await sSSTContext.ToListAsync());
        }

        // GET: MataPelajaran/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.MataPelajaran
                .Include(m => m.Guru)
                .Include(m => m.Kelas)
                .FirstOrDefaultAsync(m => m.MapelID == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return View(mataPelajaran);
        }

        // GET: MataPelajaran/Create
        public IActionResult Create()
        {
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama");
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama");
            return View();
        }

        // POST: MataPelajaran/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MapelID,MapelNama,MapelDesc,MapelGrade,GuruID,KelasID")] MataPelajaran mataPelajaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mataPelajaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama", mataPelajaran.GuruID);
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama", mataPelajaran.KelasID);
            return View(mataPelajaran);
        }

        // GET: MataPelajaran/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.MataPelajaran.FindAsync(id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama", mataPelajaran.GuruID);
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama", mataPelajaran.KelasID);
            return View(mataPelajaran);
        }

        // POST: MataPelajaran/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MapelID,MapelNama,MapelDesc,MapelGrade,GuruID,KelasID")] MataPelajaran mataPelajaran)
        {
            if (id != mataPelajaran.MapelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mataPelajaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MataPelajaranExists(mataPelajaran.MapelID))
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
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama", mataPelajaran.GuruID);
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama", mataPelajaran.KelasID);
            return View(mataPelajaran);
        }

        // GET: MataPelajaran/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataPelajaran = await _context.MataPelajaran
                .Include(m => m.Guru)
                .Include(m => m.Kelas)
                .FirstOrDefaultAsync(m => m.MapelID == id);
            if (mataPelajaran == null)
            {
                return NotFound();
            }

            return View(mataPelajaran);
        }

        // POST: MataPelajaran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mataPelajaran = await _context.MataPelajaran.FindAsync(id);
            _context.MataPelajaran.Remove(mataPelajaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MataPelajaranExists(int id)
        {
            return _context.MataPelajaran.Any(e => e.MapelID == id);
        }
    }
}

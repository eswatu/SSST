using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSST.Data;
using SSST.Models;

namespace SSST.Controllers
{
    public class KelasController : Controller
    {
        private readonly SSSTContext _context;

        public KelasController(SSSTContext context)
        {
            _context = context;
        }

        // GET: Kelas
        public async Task<IActionResult> Index()
        {
            var sSSTContext = _context.Kelas.Include(k => k.Guru);
            return View(await sSSTContext.ToListAsync());
        }
        public async Task<IActionResult> DaftarSiswaKelas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ctx = await _context.Kelas
                .Include(g => g.Guru)
                .Include(s => s.Siswas)
                .FirstOrDefaultAsync(x => x.KelasID == id);
            //StartPenilaian(id);
            if (ctx == null)
            {
                return NotFound();
            }

            return View(ctx);
        }

        //harus yakin sukses
        //public void StartPenilaian(int? id)
        //{
        //    var kls = _context.Kelas.FirstOrDefault(x => x.KelasID == id);
        //    var listMP = from lm in kls.Mapels
        //                 select lm.MapelID;

        //    var listSw = from ls in kls.Siswas
        //                 select ls.SiswaID;

        //    var listSN = _context.SiswaNilai.ToList();

        //    foreach (var sw in listSw)
        //    {

        //        foreach (var mp in listMP)
        //        {

        //            if !(listSN.Contains(x => x.SiswaID == sw ))
        //            {
        //                _context.SiswaNilai.Add(ent);
        //                _context.SaveChanges();
        //            }
        //        }
        //    }

        //}
        // GET: Kelas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelas = await _context.Kelas
                .Include(k => k.Guru)
                .FirstOrDefaultAsync(m => m.KelasID == id);
            if (kelas == null)
            {
                return NotFound();
            }

            return View(kelas);
        }

        // GET: Kelas/Create
        public IActionResult Create()
        {
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama");
            return View();
        }

        // POST: Kelas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KelasID,KelasNama,KelasTingkat,KelasTahun,GuruID")] Kelas kelas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kelas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama", kelas.GuruID);
            return View(kelas);
        }

        // GET: Kelas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelas = await _context.Kelas.FindAsync(id);
            if (kelas == null)
            {
                return NotFound();
            }
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama", kelas.GuruID);
            return View(kelas);
        }

        // POST: Kelas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KelasID,KelasNama,KelasTingkat,KelasTahun,GuruID")] Kelas kelas)
        {
            if (id != kelas.KelasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kelas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KelasExists(kelas.KelasID))
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
            ViewData["GuruID"] = new SelectList(_context.Guru, "GuruID", "GuruNama", kelas.GuruID);
            return View(kelas);
        }

        // GET: Kelas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelas = await _context.Kelas
                .Include(k => k.Guru)
                .FirstOrDefaultAsync(m => m.KelasID == id);
            if (kelas == null)
            {
                return NotFound();
            }

            return View(kelas);
        }

        // POST: Kelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kelas = await _context.Kelas.FindAsync(id);
            _context.Kelas.Remove(kelas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KelasExists(int id)
        {
            return _context.Kelas.Any(e => e.KelasID == id);
        }
    }
}

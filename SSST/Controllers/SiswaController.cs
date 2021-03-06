﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SSST.Data;
using SSST.Models;

namespace SSST.Controllers
{
    public class SiswaController : Controller
    {
        private readonly SSSTContext _context;

        public SiswaController(SSSTContext context)
        {
            _context = context;
        }

        // GET: Siswa
        public async Task<IActionResult> Index()
        {
            var sSSTContext = _context.Siswa.Include(s => s.Kelas);
            return View(await sSSTContext.ToListAsync());
        }

        // GET: Siswa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.Kelas)
                .FirstOrDefaultAsync(m => m.SiswaID == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // GET: Siswa/InputNilaiSiswa/5
        public async Task<IActionResult> InputNilaiSiswa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.Kelas)
                .FirstOrDefaultAsync(m => m.SiswaID == id);
            if (siswa == null)
            {
                return NotFound();
            }
            var listMapel = _context.MataPelajaran.Where(mp => mp.KelasID == siswa.KelasID).ToList();

            foreach (var pl in listMapel)
            {
                bool ada = _context.SiswaNilai.Any(ss => ss.SiswaID == siswa.SiswaID && ss.MapelID == pl.MapelID);
                if (!ada)
                {
                     SiswaNilai sm = new SiswaNilai { Siswa = siswa, MataPelajaran = pl };
                    _context.Add(sm);
                    _context.SaveChanges();
                }

            }

            var snl = _context.SiswaNilai.Where(s => s.SiswaID == id)
                .Include(s => s.Siswa)
                .Include(m => m.MataPelajaran);
            ViewBag.idkelas = siswa.KelasID;
            return View(snl.ToList());
        }

        // POST: Siswa/InputNilaiSiswa/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InputNilaiSiswa(int id,[Bind("SiswaID,MapelID,NilaiKKM,Nilai")] List<SiswaNilai> snl)
        {
            var idkelas = _context.Siswa.Find(id).KelasID;
            if (ModelState.IsValid)
            {
                foreach (var item in snl)
                {
                    _context.Update(item);
                    _context.SaveChanges();

                }

                return RedirectToAction("DaftarSiswaKelas","Kelas", new { id = idkelas });
            }

            return View(snl);
        }

        // GET: Siswa/LihatNilaiSiswa/5
        public async Task<IActionResult> LihatNilaiSiswa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.Kelas)
                .FirstOrDefaultAsync(m => m.SiswaID == id);
            if (siswa == null)
            {
                return NotFound();
            }
            var listMapel = _context.MataPelajaran.Where(mp => mp.KelasID == siswa.KelasID).ToList();

            foreach (var pl in listMapel)
            {
                bool ada = _context.SiswaNilai.Any(ss => ss.SiswaID == siswa.SiswaID && ss.MapelID == pl.MapelID);
                if (!ada)
                {
                    SiswaNilai sm = new SiswaNilai { Siswa = siswa, MataPelajaran = pl };
                    _context.Add(sm);
                    _context.SaveChanges();
                }

            }

            var snl = _context.SiswaNilai.Where(s => s.SiswaID == id)
                .Include(s => s.Siswa)
                .Include(m => m.MataPelajaran);
            ViewBag.idkelas = siswa.KelasID;
            return View(snl.ToList());
        }
        // GET: Siswa/Create
        public IActionResult Create()
        {
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama");
            return View();
        }

        // POST: Siswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiswaID,SiswaNim,SiswaNama,SiswaAlamat,KelasID")] Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama", siswa.KelasID);
            return View(siswa);
        }

        // GET: Siswa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama", siswa.KelasID);
            return View(siswa);
        }

        // POST: Siswa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiswaID,SiswaNim,SiswaNama,SiswaAlamat,KelasID")] Siswa siswa)
        {
            if (id != siswa.SiswaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaExists(siswa.SiswaID))
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
            ViewData["KelasID"] = new SelectList(_context.Kelas, "KelasID", "KelasNama", siswa.KelasID);
            return View(siswa);
        }

        // GET: Siswa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.Kelas)
                .FirstOrDefaultAsync(m => m.SiswaID == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // POST: Siswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siswa = await _context.Siswa.FindAsync(id);
            _context.Siswa.Remove(siswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaExists(int id)
        {
            return _context.Siswa.Any(e => e.SiswaID == id);
        }
    }
}

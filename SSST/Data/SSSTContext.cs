using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSST.Models;

namespace SSST.Data
{
    public class SSSTContext : DbContext
    {
        public SSSTContext(DbContextOptions<SSSTContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //key many to many siswa dengan nilai
            modelBuilder.Entity<SiswaNilai>().HasKey(sc => new { sc.SiswaID, sc.MapelID });
            modelBuilder.Entity<SiswaNilai>()
                .HasOne(s => s.Siswa)
                .WithMany(m => m.SiswaNilais)
                .HasForeignKey(k => k.SiswaID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SiswaNilai>()
                .HasOne(m => m.MataPelajaran)
                .WithMany(s => s.SiswaNilais)
                .HasForeignKey(k => k.MapelID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MataPelajaran>()
                .HasOne(k => k.Kelas)
                .WithMany(m => m.Mapels)
                .HasForeignKey(x => x.KelasID)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
        public DbSet<SSST.Models.Siswa> Siswa { get; set; }

        public DbSet<SSST.Models.Guru> Guru { get; set; }

        public DbSet<SSST.Models.MataPelajaran> MataPelajaran { get; set; }

        public DbSet<SSST.Models.Kelas> Kelas { get; set; }

        public DbSet<SSST.Models.SiswaNilai> SiswaNilai { get; set; }

    }
}


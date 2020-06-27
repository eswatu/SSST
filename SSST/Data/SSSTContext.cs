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
        public SSSTContext (DbContextOptions<SSSTContext> options)
            : base(options)
        {
        }

        public DbSet<SSST.Models.Siswa> Siswa { get; set; }

        public DbSet<SSST.Models.Guru> Guru { get; set; }

        public DbSet<SSST.Models.MataPelajaran> MataPelajaran { get; set; }

        public DbSet<SSST.Models.Kelas> Kelas { get; set; }

    }
}

using SSST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.ViewModel
{
    public class DaftarSiswaKelas
    {
        public int idkelasiswa { get; set; }
        public string kelasNama { get; set; }
        public string kelasGuru { get; set; }
        public List<Siswa> Anggota { get; set; }
    }
}

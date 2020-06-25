using SSST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.ViewModel
{
    public class DaftarMapelKelas
    {
        public int idmapelkelas { get; set; }
        public Kelas  kelas { get; set; }
        public  MataPelajaran mataPelajaran { get; set; }
    }
}

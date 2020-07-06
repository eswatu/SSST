using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.Models
{
    public class SiswaNilai
    {
        public int SiswaID { get; set; }
        public Siswa Siswa { get; set; }

        public int MapelID { get; set; }
        public MataPelajaran MataPelajaran { get; set; }
        public float NilaiKKM  { get; set; }
        public float Nilai { get; set; }

    }
}

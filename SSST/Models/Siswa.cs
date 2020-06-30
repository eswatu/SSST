using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.Models
{
    public class Siswa
    {
        public int SiswaID { get; set; }

        [Display(Name ="Nomor Induk Siswa"), StringLength(12)]
        public string SiswaNim { get; set; }

        [Display(Name ="Nama Siswa")]
        public string SiswaNama { get; set; }
        [Display(Name ="Alamat")]
        public string SiswaAlamat { get; set; }
        //penunjuk anggota pada kelas
        [Display(Name ="Kelas")]

        //single key, satu siswa -> satu kelas
        public int KelasID { get; set; }
        public virtual Kelas Kelas { get; set; }

        public List<SiswaNilai> SiswaNilais { get; set; }

    }
}

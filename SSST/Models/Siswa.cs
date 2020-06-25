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
        public string SiswaNim { get; set; }
        [Display(Name ="Nama Siswa")]
        public string SiswaNama { get; set; }
        [Display(Name ="Alamat")]
        public string SiswaAlamat { get; set; }

    }
}

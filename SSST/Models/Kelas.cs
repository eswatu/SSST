using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.Models
{
    public class Kelas
    {
        public int KelasID { get; set; }
        [Display(Name ="Nama Kelas")]
        public string KelasNama { get; set; }
        //KelasTahun untuk digunakan penanda angkatan
        public int KelasTahun { get; set; }
        //merujuk nama guru kelas/wali kelas
        public int guruPengampu { get; set; }

    }
}

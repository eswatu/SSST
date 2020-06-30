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
        [Display(Name ="Tahun")]
        public int KelasTahun { get; set; }
        //merujuk nama guru kelas/wali kelas
        [Display(Name ="Wali Kelas")]
        public int GuruID { get; set; }
        public Guru Guru { get; set; }
        //navigational key, satu kelas banyak siswa
        public virtual ICollection<Siswa> Siswas{ get; set; }
        //navigational key, satu kelas banyak mata pelajaran
        public virtual ICollection<MataPelajaran> Mapels { get; set; }
        public Kelas()
        {
            Mapels = new HashSet<MataPelajaran>();
            Siswas = new HashSet<Siswa>();
        }
    }
}

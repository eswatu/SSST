using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SSST.Models
{
    public class MataPelajaran
    {
       
        [Key]
        public int MapelID { get; set; }

        [Display(Name ="Nama Pelajaran")]
        public string MapelNama { get; set; }

        [Display(Name ="Keterangan")]
        public string MapelDesc { get; set; }
        [Display(Name ="Tingkat")]
        public Tingkat MapelGrade { get; set; }

        //untuk menunjuk guru pengampu
        [Display(Name ="Guru Pengampu")]
        public int GuruID { get; set; }
        public virtual Guru Guru { get; set; }

        //untuk menghubungkan kelas
        public int KelasID { get; set; }
        public virtual Kelas Kelas { get; set; }

        public List<SiswaNilai> SiswaNilais { get; set; }


    }
    public enum Tingkat
    {
        I,
        II,
        III,
        IV,
        V,
        VI,
        VII,
        VIII,
        IX,
        X,
        XI,
        XII
    }
}

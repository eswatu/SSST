using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name ="Tingkat")]
        public Tingkat MapelGrade { get; set; }

        //untuk menunjuk guru pengampu
        [Display(Name ="Guru Pengampu")]
        public int GuruMapel { get; set; }
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

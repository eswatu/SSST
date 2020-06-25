using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.Models
{
    public class MataPelajaran
    {
        public int MapelID { get; set; }
        [Display(Name ="Nama Pelajaran")]
        public string MapelNama { get; set; }
        //untuk menunjuk guru pengampu
        public int GuruMapel { get; set; }
    }
}

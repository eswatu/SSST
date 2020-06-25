using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSST.Models
{
    public class Guru
    {
        public int GuruID { get; set; }
        [Display(Name ="Nama Guru")]
        public string GuruNama { get; set; }
    }
}

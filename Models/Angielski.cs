using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlownikObcy2.Models
{
    public class Angielski
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Obcy { get; set; }
        [Required]
        public string Polski { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlownikObcy2.Models
{
    public class Japonski
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Romaji { get; set; }
        [Required]
        public string Polski { get; set; }
        [Required]
        public string Kana { get; set; }
        public string Kanji { get; set; }
    }
}

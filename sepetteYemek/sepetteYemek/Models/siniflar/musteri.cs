using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class musteri
    {
        [Key]
        public int musteriid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string musteriAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string musteriSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string musteriSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string musteriMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string musteriSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<satisHareket> SatisHarekets { get; set; }
    }
}
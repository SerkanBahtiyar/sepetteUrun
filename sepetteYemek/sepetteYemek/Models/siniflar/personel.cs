﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace sepetteYemek.Models.siniflar
{
    public class personel
    {

        [Key]
        public int Personelid { get; set; }

        [Display(Name = "Personel Adı")]

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Display(Name = "Personel Soyadı")]

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Display(Name = "Personel Görsel")]

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<satisHareket> SatisHarekets { get; set; }
        //bir personel sadece bir depatmanda bulunabilir
        public int departmanid { get; set; }
        public virtual departman Departman { get; set; }
    }
}
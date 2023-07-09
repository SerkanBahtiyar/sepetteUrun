﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class satisHareket
    {

        [Key]
        public int Satisid { get; set; }

        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int Urunid { get; set; }
        public int musteriid { get; set; }
        public int Personelid { get; set; }
        public virtual urunler Urun { get; set; }
        public virtual musteri Musteriler { get; set; }
        public virtual personel Personel { get; set; }
    }
}
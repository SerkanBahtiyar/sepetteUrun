using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        context sb=new context();
        public ActionResult Index()
        {
            var deger1 = sb.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = sb.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = sb.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = sb.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = sb.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in sb.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = sb.Uruns.Count(x => x.Stok <= 50).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in sb.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in sb.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = sb.Uruns.Count(x => x.UrunAd == "Su").ToString();
            ViewBag.d10 = deger10;
            var deger11 = sb.Uruns.Count(x => x.UrunAd == "Bebek Bezi").ToString();
            ViewBag.d11 = deger11;
            var deger12 = sb.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = sb.Uruns.Where(u => u.Urunid == sb.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = sb.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = sb.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.Adet).ToString();
            ViewBag.d15 = deger15;
            var deger16 = sb.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar * y.Adet).ToString();
            ViewBag.d16 = deger16;

            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in sb.Carilers
                        group x by x.musteriSehir into g
                        select new sinifGrup
                        {
                            Sehir = g.Key,  // g grubun içine dahil olacak alanımız
                            Sayi = g.Count()  //grubumu sayıcağı ifade
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {  //layout tamamını kaplıyor particial bir kısımını
            var sorgu2 = from x in sb.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new sinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = sb.Carilers.ToList();

            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = sb.Uruns.ToList();

            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu3 = from x in sb.Uruns
                         group x by x.Marka into g
                         select new sinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu3.ToList());

        }
    }
}
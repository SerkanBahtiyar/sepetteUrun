using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class satisController : Controller
    {
        // GET: satis
        context sb=new context();
        public ActionResult Index()
        {
            var degerler = sb.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in sb.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in sb.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.musteriAd + " " + x.musteriSoyad,
                                               Value = x.musteriid.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in sb.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(satisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            sb.SatisHarekets.Add(s);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in sb.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in sb.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.musteriAd + " " + x.musteriSoyad,
                                               Value = x.musteriid.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in sb.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = sb.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(satisHareket p)
        {
            var deger = sb.SatisHarekets.Find(p.Satisid);
            deger.musteriid = p.musteriid;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.Personelid = p.Personelid;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.Urunid = p.Urunid;
            sb.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisDetay(int id)
        {
            var deger = sb.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(deger);
        }

    }
}
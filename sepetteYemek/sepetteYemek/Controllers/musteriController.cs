using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class musteriController : Controller
    {
        // GET: musteri
        context sb = new context();
        public ActionResult Index()
        {
            var degerler = sb.Carilers.Where(s => s.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult YeniMusteri()
        {

            return View();
        }
        [HttpPost]

        public ActionResult YeniMusteri(musteri cr)
        {
            cr.Durum = true;
            sb.Carilers.Add(cr);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musteriSil(int id)
        {
            var cr = sb.Carilers.Find(id);
            cr.Durum = false;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musteriGetir(int id)
        {
            var cari = sb.Carilers.Find(id);
            return View("musteriGetir", cari);
        }
        public ActionResult musteriGuncelle(musteri ca)
        {

            var cari = sb.Carilers.Find(ca.musteriid);
            cari.musteriAd = ca.musteriAd;
            cari.musteriSoyad = ca.musteriSoyad;
            cari.musteriSehir = ca.musteriSehir;
            cari.musteriMail = ca.musteriMail;

            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musteriSatis(int id)
        {
            var satislar = sb.SatisHarekets.Where(s => s.musteriid == id).ToList();
            var cr = sb.Carilers.Where(s => s.musteriid == id).Select(b => b.musteriAd + " " + b.musteriSoyad).FirstOrDefault();
            ViewBag.cari = cr;

            return View(satislar);
        }
    }
}
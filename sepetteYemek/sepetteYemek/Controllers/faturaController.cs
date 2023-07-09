using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class faturaController : Controller
    {
        // GET: fatura
        context sb=new context();
        public ActionResult Index()
        {
            var liste = sb.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        //[Authorize(Roles = "A")]
         public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(faturalar f)
        {
            sb.Faturalars.Add(f);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = sb.Faturalars.Find(id);
            return View("FaturaGetir", fatura);

        }
        public ActionResult FaturaGuncelle(faturalar f)
        {
            var fatura = sb.Faturalars.Find(f.Faturaid);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            sb.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = sb.FaturaKalems.Where(s => s.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(faturaKalem p)
        {
            sb.FaturaKalems.Add(p);
            sb.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
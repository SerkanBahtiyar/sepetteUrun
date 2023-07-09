using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        //işin back end tarafı controllerdir
        //birer metod yazılır.
        context sb = new context();
        public ActionResult Index()
        {
            var degerler = sb.Kategoris.ToList();
            return View(degerler);
         
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori k)
        {
            sb.Kategoris.Add(k);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kt = sb.Kategoris.Find(id);
            sb.Kategoris.Remove(kt);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kt = sb.Kategoris.Find(id);
            return View("KategoriGetir", kt);
        }
        public ActionResult KategoriGuncelle(kategori s)
        {
            var ktg = sb.Kategoris.Find(s.KategoriID);
            ktg.KategoriAd = s.KategoriAd;
            sb.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
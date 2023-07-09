using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class urunController : Controller
    {
        // GET: urun
        context sb= new context();
        public ActionResult Index(string p)
        {

            //var degerler = from x in sb.Uruns select x;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    degerler = degerler.Where(y => y.UrunAd.Contains(p));

            //}
            //return View(degerler.ToList());

            var urunler=sb.Uruns.Where(s=>s.Durum==true). ToList();
            return View(urunler);
            //sadace true değerleri döndür
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in sb.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()

                                           }).ToList();
            ViewBag.x = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(urunler p)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string yol = "~/UrunImage/" + dosyaadi + uzanti;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    p.UrunGorsel = "/UrunImage/" + dosyaadi + uzanti;
            //}
            //p.Durum = true;
            sb.Uruns.Add(p);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = sb.Uruns.Find(id);
            deger.Durum = false;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from sb in sb.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = sb.KategoriAd,
                                               Value = sb.KategoriID.ToString()

                                           }).ToList();
            ViewBag.sb = deger1;
            var urundeger = sb.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(urunler p)
        {
            var urn = sb.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = sb.Uruns.ToList();
            return View(degerler);
        }
    }
}
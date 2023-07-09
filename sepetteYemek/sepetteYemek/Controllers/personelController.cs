using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class personelController : Controller
    {
        // GET: personel
        context sb=new context();
        public ActionResult Index(string p)
        {
            var degerler = from x in sb.Personels select x;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(y => y.PersonelAd.Contains(p));

            }
            return View(degerler.ToList());
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult personelEkle()
        {
            List<SelectListItem> deger1 = (from x in sb.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()

                                           }).ToList();
            ViewBag.x = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult personelEkle(personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            sb.Personels.Add(p);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult personelGetir(int id)
        {
            List<SelectListItem> deger2 = (from x in sb.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger2;

            var prs = sb.Personels.Find(id);
            return View("PersonelGetir", prs);

        }
        public ActionResult PersonelGuncelle(personel p)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string yol = "~/Image/" + dosyaadi + uzanti;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            //}
            var prs = sb.Personels.Find(p.Personelid);
            prs.PersonelAd = p.PersonelAd;
            prs.PersonelSoyad = p.PersonelSoyad;
            prs.PersonelGorsel = p.PersonelGorsel;
            prs.departmanid = p.departmanid;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
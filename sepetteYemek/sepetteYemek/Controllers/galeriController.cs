using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class galeriController : Controller
    {
        // GET: galeri
        context sb = new context();
        public ActionResult Index()
        {
            var degerler = sb.Uruns.ToList();
            return View(degerler);
        }
    }
}
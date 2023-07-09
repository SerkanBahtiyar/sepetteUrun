using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    public class haritaController : Controller
    {
        // GET: harita
        public ActionResult Index()
        {
            return View();
        }
    }
}
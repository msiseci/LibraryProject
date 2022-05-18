using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var deger1 = db.Member.Count();
            var deger2 = db.Book.Count();
            var deger3 = db.Book.Where(x => x.Status == false).Count();
            var deger4 = db.Punishment.Sum(x=> x.Money);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }

            return RedirectToAction("Galeri");
        }
        
    }
}
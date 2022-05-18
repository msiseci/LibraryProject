using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.Staff.ToList();

            return View(degerler);
        }
        [HttpGet] /* Bu method HTTPGET olunca çalışsın */
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Staff p)
        {
            if(!ModelState.IsValid) // data annotationstaki gecerlilik sağlanmadıysa Personeli geri döndür
            {
                return View("PersonelEkle");
            }
            db.Staff.Add(p); /* ekleme sayfasından gelen p değerlerini categorye ekle */
            db.SaveChanges();  /* değişiklikleri kaydet */
            return View(); /* sayfayı geri döndürsün. */
        }
        public ActionResult PersonelSil(int id) /* Id ye göre sildirdigimiz icin int prmt. aldı */
        {
            var stf = db.Staff.Find(id);
            db.Staff.Remove(stf);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prsnl = db.Staff.Find(id);
            return View("PersonelGetir", prsnl); 

        }

        public ActionResult PersonelGuncelle(Staff p)
        {
            var prs = db.Staff.Find(p.Id);
            prs.Staff1 = p.Staff1;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
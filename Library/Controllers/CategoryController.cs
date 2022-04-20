using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.Category.ToList();

            return View(degerler);
        }

        [HttpGet] /* Bu method HTTPGET olunca çalışsın */
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category p)
        {
            db.Category.Add(p); /* ekleme sayfasından gelen p değerlerini categorye ekle */
            db.SaveChanges();  /* değişiklikleri kaydet */
            return View(); /* sayfayı geri döndürsün. */
        }
    }
}
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
            var degerler = db.Category.Where(x=>x.Status == true).ToList();

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

        public ActionResult KategoriSil(int id) /* Id ye göre sildirdigimiz icin int prmt. aldı */
        {
            var category = db.Category.Find(id);
            //db.Category.Remove(category);
            category.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Category.Find(id);
            return View("KategoriGetir", ktg); /* ktg den gelen değerle döndür */
        
        }

        public ActionResult KategoriGuncelle(Category p)
        {
            var ktg = db.Category.Find(p.Id);
            ktg.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }  
}
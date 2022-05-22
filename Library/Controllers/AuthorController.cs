using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.Author.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        public ActionResult YazarEkle(Author p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.Author.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.Author.Find(id);
            db.Author.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.Author.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle(Author p)
        {
            var yzr = db.Author.Find(p.Id);
            yzr.AuthorName = p.AuthorName; /* yzr den gelen  ad değeri p den gelen ad değeri olcak */
            yzr.AuthorSurname = p.AuthorSurname;
            yzr.Detail = p.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.Book.Where(x => x.Author == id).ToList();
            var yzrad = db.Author.Where(y => y.Id == id).Select(z => z.AuthorName + " "
                 + z.AuthorSurname).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(yazar);
        }
    }


}
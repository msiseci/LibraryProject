using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Book select k;
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.BookName.Contains(p));
            }
            //var kitaplar = db.Book.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorName +' '+ i.AuthorSurname,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(Book p)
        {
            var ktg = db.Category.Where(k => k.Id == p.Category1.Id).FirstOrDefault();
            var yzr = db.Author.Where(y => y.Id == p.Author1.Id).FirstOrDefault();
            p.Category1 = ktg;
            p.Author1=yzr;
            db.Book.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.Book.Find(id);
            db.Book.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.Book.Find(id);
            List<SelectListItem> deger1 = (from i in db.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.Author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorName + ' ' + i.AuthorSurname,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(Book p)
        {
            var kitap = db.Book.Find(p.Id);
            kitap.BookName = p.BookName;
            kitap.PublicationYear = p.PublicationYear;
            kitap.Page = p.Page;
            kitap.Publisher = p.Publisher;
            kitap.Status = true;
            var ktg = db.Category.Where(k => k.Id == p.Category1.Id).FirstOrDefault();
            var yzr = db.Author.Where(y => y.Id == p.Author1.Id).FirstOrDefault();
            kitap.Category = ktg.Id;
            kitap.Author = yzr.Id;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
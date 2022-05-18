using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using Library.Models.MyClass;

namespace Library.Controllers
{
    public class WindowController : Controller
    {
        // GET: Window
        DbLibraryEntities db = new DbLibraryEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Book.ToList();
            cs.Deger2 = db.About.ToList();
            //var degerler = db.Book.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Contact t)
        {
            db.Contact.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
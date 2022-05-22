using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.Announcements.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(Announcements d)
        {
            db.Announcements.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil (int id)
        {
            var duyuru = db.Announcements.Find(id);
            db.Announcements.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(Announcements p)
        {
            var duyuru = db.Announcements.Find(p.Id);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGüncelle(Announcements t)
        {
            var duyuru = db.Announcements.Find(t.Id);
            duyuru.Category = t.Category;
            duyuru.Contents = t.Contents;
            duyuru.Date = t.Date;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
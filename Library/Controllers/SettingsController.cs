using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var kullanicilar = db.Admin.ToList();
            return View(kullanicilar);
        }
        public ActionResult Index2()
        {
            var kullanicilar = db.Admin.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(Admin t)
        {
            db.Admin.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.Admin.Find(id);
            db.Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.Admin.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(Admin p)
        {
            var admin = db.Admin.Find(p.Id);
            admin.AdminUser = p.AdminUser;
            admin.Password = p.Password;
            admin.Authority = p.Authority;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}
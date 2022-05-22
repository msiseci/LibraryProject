using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library.Models.Entity;

namespace Library.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        DbLibraryEntities db = new DbLibraryEntities();
        [HttpGet]
        
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.Member.FirstOrDefault(z => z.Email == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(Member p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Member.FirstOrDefault(x => x.Email == kullanici);
            uye.Password = p.Password;
            uye.MemberName = p.MemberName;
            uye.Photo = p.Photo;
            uye.School = p.School;
            uye.UserName = p.UserName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.Member.Where(x => x.Email == kullanici.ToString()).Select(z => z.Id).FirstOrDefault();
            var degerler = db.Action.Where(x => x.Member == id).ToList();
            return View(degerler);
        }
      
        public ActionResult Duyurular()
        {
            var duyurulist = db.Announcements.ToList();
            return View(duyurulist);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }

}
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
            //var degerler = db.Member.FirstOrDefault(z => z.Email == uyemail);
            var degerler = db.Announcements.ToList();
            
            var d1 = db.Member.Where(x => x.Email == uyemail).Select(y => y.MemberName).FirstOrDefault();
            ViewBag.d1 = d1;
            
            var d2 = db.Member.Where(x => x.Email == uyemail).Select(y => y.MemberSurname).FirstOrDefault();
            ViewBag.d2 = d2;
            
            var d3 = db.Member.Where(x => x.Email == uyemail).Select(y => y.Photo).FirstOrDefault();
            ViewBag.d3 = d3;
            
            var d4 = db.Member.Where(x => x.Email == uyemail).Select(y => y.UserName).FirstOrDefault();
            ViewBag.d4 = d4;
            
            var d5= db.Member.Where(x => x.Email == uyemail).Select(y => y.School).FirstOrDefault();
            ViewBag.d5 = d5;
            
            var d6 = db.Member.Where(x => x.Email == uyemail).Select(y => y.Phone).FirstOrDefault();
            ViewBag.d6 = d6;
            
            var d7 = db.Member.Where(x => x.Email == uyemail).Select(y => y.Email).FirstOrDefault();
            ViewBag.d7 = d7;
            
            var uyeid = db.Member.Where(x => x.Email == uyemail).Select(y => y.Id).FirstOrDefault();
            var d8 = db.Action.Where(x => x.Member == uyeid).Count();
            ViewBag.d8 = d8;

            var d9 = db.Messages.Where(x => x.Alıcı == uyemail).Count();
            ViewBag.d9 = d9;

            var d10 = db.Announcements.Count();
            ViewBag.d10 = d10;

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
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.Member.Where(x => x.Email == kullanici).Select(y => y.Id).FirstOrDefault();
            var uyebul = db.Member.Find(id);
            return PartialView("Partial2",uyebul);
        }
    }

}
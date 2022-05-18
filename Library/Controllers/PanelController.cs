using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        DbLibraryEntities db = new DbLibraryEntities();
        [HttpGet]
        [Authorize]
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
    }

}
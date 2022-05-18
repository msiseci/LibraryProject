using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Library.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Member.ToList();
            var degerler = db.Member.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet] /* Bu method HTTPGET olunca çalışsın */
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Member u)
        {
            if (!ModelState.IsValid) // data annotationstaki gecerlilik sağlanmadıysa Personeli geri döndür
            {
                return View("UyeEkle");
            }
            db.Member.Add(u); 
            db.SaveChanges();  
            return View(); 
        }
        public ActionResult UyeSil(int id) /* Id ye göre sildirdigimiz icin int prmt. aldı */
        {
            var uye = db.Member.Find(id);
            db.Member.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.Member.Find(id);
            return View("UyeGetir", uye); /* ktg den gelen değerle döndür */

        }

        public ActionResult UyeGuncelle(Member p)
        {
            var uye = db.Member.Find(p.Id);
            uye.MemberName = p.MemberName;
            uye.MemberSurname = p.MemberSurname;
            uye.Email = p.Email;
            uye.UserName = p.UserName;
            uye.Password = p.Password;
            uye.School = p.School;
            uye.Phone = p.Phone;
            uye.Photo = p.Photo;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
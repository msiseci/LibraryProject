using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Messages.Where(x => x.Alıcı == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Messages.Where(x => x.Gönderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Messages t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.Gönderen = uyemail.ToString();
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Messages.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden","Message");
        }
    }
}
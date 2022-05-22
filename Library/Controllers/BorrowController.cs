using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using Action = Library.Models.Entity.Action;

namespace Library.Controllers
{
    public class BorrowController : Controller
    {
        // GET: Borrow
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.Action.Where(x => x.ProcessStatus == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.Member.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MemberName + " " + x.MemberSurname,
                                               Value = x.Id.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from y in db.Book.Where(x=>x.Status== true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.BookName,
                                               Value = y.Id.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from z in db.Staff.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.Staff1,
                                               Value = z.Id.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(Action p)
        {
            var d1 = db.Member.Where(x => x.Id == p.Member1.Id).FirstOrDefault();
            var d2 = db.Book.Where(y => y.Id == p.Book1.Id).FirstOrDefault();
            var d3 = db.Staff.Where(z => z.Id == p.Staff1.Id).FirstOrDefault();
            p.Member1 = d1;
            p.Book1 = d2;
            p.Staff1 = d3;
            db.Action.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OduncIade(Action p)
        {
            var odn = db.Action.Find(p.Id);
            DateTime d1 = DateTime.Parse(odn.ReturnDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;

            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(Action p)
        {
            var act = db.Action.Find(p.Id);
            act.MemberDate = p.MemberDate;
            act.ProcessStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
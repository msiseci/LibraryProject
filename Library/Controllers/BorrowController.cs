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
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(Action p)
        {
            db.Action.Add(p);   
            db.SaveChanges();  
            return View(); 
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
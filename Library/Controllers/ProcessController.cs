using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.Action.Where(x => x.ProcessStatus == true).ToList();
            return View(degerler);
        }
    }
}
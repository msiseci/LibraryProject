using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DbLibraryEntities db = new DbLibraryEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit (Member p)
        {
            if(!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.Member.Add(p);
            db.SaveChanges();
            return View();
            
        }
    }
}
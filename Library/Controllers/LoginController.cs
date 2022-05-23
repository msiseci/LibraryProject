using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using System.Web.Security;

namespace Library.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Member p)
        {
            var bilgiler = db.Member.FirstOrDefault(x => x.Email == p.Email &&
            x.Password == p.Password);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                Session["Mail"] = bilgiler.Email.ToString();
                
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
            
        }

    }
}
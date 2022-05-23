using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library.Models.Entity;

namespace Library.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
       
        // GET: AdminLogin
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var bilgiler = db.Admin.FirstOrDefault(x=>x.AdminUser == p.AdminUser &&
            x.Password==p.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminUser, false);
                Session["AdminUser"] = bilgiler.AdminUser.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(bilgiler);
            }

           
        }
    }
}
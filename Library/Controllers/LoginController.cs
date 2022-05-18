using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using System.Web.Security;

namespace Library.Controllers
{
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
                //TempData["Id"] = bilgiler.Id.ToString();
                //TempData["Ad"] = bilgiler.MemberName.ToString();
                //TempData["Soyad"] = bilgiler.MemberSurname.ToString();
                //TempData["Kullanıcı Adı"] = bilgiler.UserName.ToString();
                //TempData["Şifre"] = bilgiler.Password.ToString();
                //TempData["Okul"] = bilgiler.School.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
            
        }
    }
}
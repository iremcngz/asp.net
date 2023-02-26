using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Travel.Models.Sinif;
namespace Travel.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(Admin ad)
        {
            var information = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && 
                                                                      x.Sifre == ad.Sifre);
            if(information != null)
            {
                FormsAuthentication.SetAuthCookie(information.Kullanici, false);
                Session["Kullanici"] = information.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }

        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "LogIn");
        }

    }
}
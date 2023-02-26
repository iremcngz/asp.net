using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sinif;

namespace Travel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var val = c.Blogs.ToList();
            return View(val);
        }


        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var deg = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(deg);
        }

        public PartialViewResult Partial2()
        {
            var de = c.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(de);
        }


        public PartialViewResult Partial3()
        {
            var deg = c.Blogs.Take(10).ToList();
            return PartialView(deg);
        }



        public PartialViewResult Partial4()
        {
            var deg = c.Blogs.Take(3).ToList();
            return PartialView(deg);
        }

        public PartialViewResult Partial5()
        {
            var deg = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deg);
        }
    }
}
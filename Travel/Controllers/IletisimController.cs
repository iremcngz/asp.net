using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sinif;

namespace Travel.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        public ActionResult Index()
        {
          
            return View();
        }


        Context c = new Context();

        [HttpGet]
        public PartialViewResult Partial6(int ID)
        {
            ViewBag.deger = ID;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial6(Travel.Models.Sinif.iletisim i)
        {
            c.iletisims.Add(i);
            c.SaveChanges();
            return PartialView();
        }


        public ActionResult MesajGetir(int id)
        {
            var ms = c.Blogs.Find(id);
            return View("MesajGetir", ms);

        }







        public ActionResult IletisimMesajiSil(int id)
        {
            var m = c.iletisims.Find(id);
            c.iletisims.Remove(m);
            c.SaveChanges();
            return RedirectToAction("Iletisim");

        }




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sinif;
namespace Travel.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.var1 = c.Blogs.ToList();
            by.var3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }

        
        public ActionResult BlogDetay(int id)
        {
          //  var blogBul = c.Blogs.Where(x => x.ID == id).ToList();
            by.var1=c.Blogs.Where(x => x.ID == id).ToList();
            by.var2 = c.Yorumlars.Where(x => x.blogID == id).ToList();
            return View(by);
        }





        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }



        [HttpPost]
        public PartialViewResult YorumYap(Travel.Models.Sinif.Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}
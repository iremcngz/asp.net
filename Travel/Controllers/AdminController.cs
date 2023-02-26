using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Sinif;
namespace Travel.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deg = c.Blogs.ToList();
            return View(deg);
        }


        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Travel.Models.Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult BlogSil(int ID)
        {
            var b = c.Blogs.Find(ID);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir",bl);

        }


        public ActionResult BlogGüncelle(Travel.Models.Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var y = c.Yorumlars.ToList();
            return View(y);
        }


        public ActionResult YorumSil(int ID)
        {
            var b = c.Yorumlars.Find(ID);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        public ActionResult YorumGüncelle(Travel.Models.Sinif.Yorumlar y)
        {
            var yr = c.Yorumlars.Find(y.ID);
            yr.KullaniciAdi = y.KullaniciAdi;
            yr.Mail = y.Mail;
            yr.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }





        public ActionResult Iletisim()
        {
            var m = c.iletisims.ToList();
            return View(m);
        }

    }
}
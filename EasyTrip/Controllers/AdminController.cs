using EasyTrip.Models.Siniflar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTrip.Controllers
{
    public class AdminController : Controller
    {
        public Context _context;
        public AdminController(Context context)
        {
            _context = context;
        }
        [Authorize]
        public ActionResult Index()
        {
            var degerler = _context.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            _context.Blogs.Add(p);  
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = _context.Blogs.Find(id);
            _context.Blogs.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = _context.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = _context.Blogs.Find(b.ID);
            blg.Aciklma = b.Aciklma;
            blg.Baslik =b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = _context.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var y = _context.Yorumlars.Find(id);
            _context.Yorumlars.Remove(y);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumGetir(int id)
        {
            var ym = _context.Yorumlars.Find(id);
            return View("YorumGetir", ym);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = _context.Yorumlars.Find(y.ID);
            yrm.KullniciAdi = y.KullniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            _context.SaveChanges();
           return RedirectToAction("YorumListesi");
        }

    }
}

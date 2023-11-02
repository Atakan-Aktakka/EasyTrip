using Microsoft.AspNetCore.Mvc;
using EasyTrip.Models.Siniflar;
namespace EasyTrip.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;
        public DefaultController(Context context)
        {
            _context = context;
            //ienumerable iqueryable ilist difference c#
        }
        public ActionResult Index()
        {
           var degerler = _context.Blogs.Take(10).ToList();
            return View(degerler);
        }
        public ActionResult About()
        {

            return View();
        }
        public PartialViewResult Partial1()
        {
            var degerler = _context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var degerler = _context.Blogs.Where(x=>x.ID==1).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial3()
        {
            var deger = _context.Blogs.Take(10).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = _context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = _context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deger);
        }
    }
}
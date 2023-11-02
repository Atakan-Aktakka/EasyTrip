using Microsoft.AspNetCore.Mvc;
using EasyTrip.Models.Siniflar;
namespace EasyTrip.Controllers
{
	public class BlogController : Controller
	{
        private readonly Context _context;
        public BlogController(Context context)
        {
            _context = context;
        }
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
		{
			//var bloglar = c.Blogs.ToList();
			by.Deger1 = _context.Blogs.ToList();
			by.Deger3 = _context.Blogs.Take(3).ToList();
			return View(by);
		}
		
		public ActionResult BlogDetay(int id)
		{

			//var blogbul = c.Blogs.Where(x=> x.ID == id).ToList();
			by.Deger1 = _context.Blogs.Where(x => x.ID == id).ToList();
			by.Deger2 = _context.Yorumlars.Where(x => x.Blogid == id).ToList();
			return View(by);
		}
		[HttpGet]
		public PartialViewResult YorumYap(int id)
		{
			ViewBag.deger = id;
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult YorumYap(Yorumlar y)
		{
			_context.Yorumlars.Add(y);
			_context.SaveChanges();
			return PartialView();
		}
	}
}

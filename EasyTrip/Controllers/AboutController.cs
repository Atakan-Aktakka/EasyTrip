using Microsoft.AspNetCore.Mvc;
using EasyTrip.Models.Siniflar;
namespace EasyTrip.Controllers
{
	public class AboutController : Controller
	{
		private readonly Context _context;
		public AboutController(Context context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var degerler = _context.Hakkimizdas.ToList();
			return View(degerler);
		}
	}
}

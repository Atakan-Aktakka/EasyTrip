using EasyTrip.Models.Siniflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace EasyTrip.Controllers
{
	public class GirisYapController : Controller
	{
		private readonly Context _context;

		public GirisYapController(Context context)
		{
			_context = context;
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(Admin ad)
		{
			var bilgiler = _context.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
			if (bilgiler != null)
			{
				// Authentication
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, bilgiler.Kullanici.ToString())
                    // Add more claims if needed
                };

				var userIdentity = new ClaimsIdentity(claims, "login");
				var principal = new ClaimsPrincipal(userIdentity);

				await HttpContext.SignInAsync(principal);

				// Session
				HttpContext.Session.SetString("Kullanici", bilgiler.Kullanici.ToString());

				return RedirectToAction("Index", "Admin");
			}
			else
			{
				return View();
			}
		}
		public async Task<IActionResult> Logout()
		{
			// Kimlik doğrulama işlemi
			await HttpContext.SignOutAsync();

			// Oturumu temizleme
			HttpContext.Session.Clear();

			// Ana sayfaya yönlendirme
			return RedirectToAction("Login", "Girisyap");
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace PastebinProject.Controllers
{
	public class PastebinController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Pastebin()
		{
			return View();
		}

	}
}

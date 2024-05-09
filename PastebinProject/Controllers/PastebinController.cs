using Microsoft.AspNetCore.Mvc;

namespace PastebinProject.Controllers
{
	public class PastebinController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

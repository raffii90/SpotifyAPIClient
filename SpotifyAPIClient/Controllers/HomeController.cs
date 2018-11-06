using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/About
        public IActionResult About()
        {
            return View();
        }
    }
}

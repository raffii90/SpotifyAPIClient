using Microsoft.AspNetCore.Mvc;

namespace CloudNineAssignment.Controllers
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

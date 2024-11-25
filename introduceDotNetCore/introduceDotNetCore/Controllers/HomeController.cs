using introduceDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Türkay";
            ViewBag.Hour = DateTime.Now.Hour;

            ViewBag.Countries= new List<string>
            {
                "Türkiye",
                "Germany",
                "France",
                "Italy",
                "Spain"
            };
            return View();
        }

        [HttpGet]
        public IActionResult Rsvp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rsvp(UserResponse userResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Tesekkurler",userResponse);
            }
            return View();
        }
    }
}

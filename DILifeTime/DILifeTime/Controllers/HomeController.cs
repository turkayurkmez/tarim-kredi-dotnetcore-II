using DILifeTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DILifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton singleton;
        private readonly IScoped scoped;
        private readonly ITransient transient;
        private readonly PoCService poCService;


        public HomeController(ILogger<HomeController> logger, ISingleton singleton, IScoped scoped, ITransient transient, PoCService poCService)
        {
            _logger = logger;
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
            this.poCService = poCService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid;
            ViewBag.Scoped = scoped.Guid;
            ViewBag.Transient = transient.Guid;

            ViewBag.PoCSingleton = poCService.Singleton.Guid;
            ViewBag.PoCScoped = poCService.Scoped.Guid;
            ViewBag.PoCTransient = poCService.Transient.Guid;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

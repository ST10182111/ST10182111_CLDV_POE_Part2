using Microsoft.AspNetCore.Mvc;
using ST10182111_2024POE.Models;
using System.Diagnostics;

namespace ST10182111_2024POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Who are we ? ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = " get ahold of us";

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

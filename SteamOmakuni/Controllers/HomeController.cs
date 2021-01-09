using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SteamOmakuni.Models;
using System.Diagnostics;

namespace SteamOmakuni.Controllers
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
            ViewBag.Apps = DAO.RetrieveApps();
            ViewBag.Counts = DAO.RetrieveCounts();
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
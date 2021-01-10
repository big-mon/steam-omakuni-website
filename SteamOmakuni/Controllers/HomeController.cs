﻿using Microsoft.AspNetCore.Mvc;
using SteamOmakuni.Models;
using System.Diagnostics;

namespace SteamOmakuni.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Counts = DAO.RetrieveCounts();
            return View(DAO.RetrieveApps());
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
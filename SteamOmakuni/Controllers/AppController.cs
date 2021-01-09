using Microsoft.AspNetCore.Mvc;
using SteamOmakuni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamOmakuni.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index(int ID)
        {
            Models.Data.App app = DAO.RetrieveSelectApp(ID.ToString());
            ViewBag.title = app.Name;

            return View(app);
        }
    }
}

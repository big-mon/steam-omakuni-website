using Microsoft.AspNetCore.Mvc;
using SteamOmakuni.Models;
using System.Collections.Generic;

namespace SteamOmakuni.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Developer(string name)
        {
            List<Models.Data.App> apps = DAO.RetrieveSelectCompany(true, name);
            ViewBag.title = name;
            return View("/Views/Company/Index.cshtml", apps);
        }

        public IActionResult Publisher(string name)
        {
            List<Models.Data.App> apps = DAO.RetrieveSelectCompany(false, name);
            ViewBag.title = name;
            return View("/Views/Company/Index.cshtml", apps);
        }
    }
}
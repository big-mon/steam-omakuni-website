using Microsoft.AspNetCore.Mvc;
using SteamOmakuni.Models;

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
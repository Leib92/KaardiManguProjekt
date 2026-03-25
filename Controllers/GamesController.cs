using Microsoft.AspNetCore.Mvc;

namespace KaardiManguProject.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

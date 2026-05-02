using Microsoft.AspNetCore.Mvc;

namespace KaardiManguProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

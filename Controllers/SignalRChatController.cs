using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.ServiceInterface;
using KaardiManguProject.Data;
using KaardiManguProject.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaardiManguProject.Controllers
{
    public class SignalRChatController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SignalRChatController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new ChatViewModel { };

            vm.DisplayName = user.AvatarName;
           
            return View("Index", vm);
        }
    }
}

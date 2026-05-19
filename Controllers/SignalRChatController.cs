using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.ServiceInterface;
using KaardiManguProject.Data;
using KaardiManguProject.KaardiManguProject.Core.Domain;
using KaardiManguProject.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaardiManguProject.Controllers
{
    public class SignalRChatController : Controller
    {
        private readonly KaardiManguProjectTARpe24Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SignalRChatController(KaardiManguProjectTARpe24Context context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new ChatViewModel { };

            vm.DisplayName = user.AvatarName;
            vm.AccountId = user.Id;

            string joinmessage = vm.DisplayName + " joined the chat";

            var messagelog = new ChatLog()
            {
                MessageID = Guid.NewGuid(),
                AccountID = vm.AccountId,
                MessageText = joinmessage,
                Date = DateTime.UtcNow

            };
            await _context.ChatLog.AddAsync(messagelog);
            await _context.SaveChangesAsync();

            return View("Index", vm);
        }

        public async Task LeaveMessage()
        {
            var user = await _userManager.GetUserAsync(User);
            string joinmessage = user + " left the chat";

            var messagelog = new ChatLog()
            {
                MessageID = Guid.NewGuid(),
                AccountID = user.Id,
                MessageText = joinmessage,
                Date = DateTime.UtcNow

            };
            await _context.ChatLog.AddAsync(messagelog);
            await _context.SaveChangesAsync();
        }

    }
}

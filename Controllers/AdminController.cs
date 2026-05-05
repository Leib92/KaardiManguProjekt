using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.ServiceInterface;
using KaardiManguProject.Data;
using KaardiManguProject.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace KaardiManguProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly KaardiManguProjectTARpe24Context _context;
        private readonly IEmailsServices _emailsServices;  //HOMEWORK LOCATION ???

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, KaardiManguProjectTARpe24Context context, IEmailsServices emailsServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailsServices = emailsServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(_context.ApplicationUsers);
        }
        [HttpGet]
        public async Task<IActionResult> PunishUser(Guid? Id)
        {
            ApplicationUser user = await _context.ApplicationUsers.FindAsync(Id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            user.Id = Id.ToString();
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddDays(7);
            _context.ApplicationUsers.Update(user);
            await _context.SaveChangesAsync();
            return View(user);
        }
        /*[HttpPost, ActionName("PunishUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PunishUser([Bind("LockoutEnd")] ApplicationUser user)
        {
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddDays(7);
            _context.ApplicationUsers.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/
    }
}

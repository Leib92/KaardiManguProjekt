using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.ServiceInterface;
using KaardiManguProject.Data;
using KaardiManguProject.KaardiManguProject.Core.Domain;
using KaardiManguProject.Migrations;
using KaardiManguProject.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> ChatlogView()
        {
            var result = _context.ChatLog.OrderBy(ab => ab.Date);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> ChatlogView(DateTime FromDate, DateTime ToDate)
        {
            var result = _context.ChatLog.OrderBy(ab => ab.Date).Where(ab => ab.Date >= FromDate && ab.Date <= ToDate.AddSeconds(1));
            return View("ChatlogView",result);
        }

        public async Task<IActionResult> Filter()
        {

            var filter = await _context.Filter.FirstOrDefaultAsync();
            if (filter == null)
            {
                filter = new Filter
                {
                    FilterID = Guid.Parse("ae7c0f13-1139-4859-a100-054f547b86ec"),
                    FilterData = "bomboclaat,sybau,fuck"
                };
                _context.Filter.Add(filter);
                await _context.SaveChangesAsync();
            }
            //var words = filter.FilterData;
            return View(filter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FilterUpdate(Filter filter)
        {
            //Filter filter = await _context.Filter.FirstOrDefaultAsync();
            filter.FilterID = Guid.Parse("ae7c0f13-1139-4859-a100-054f547b86ec");
            /*if (update == null)
            {
                update = "";
            }
            filter.FilterData = update;*/
            _context.Filter.Update(filter);
            await _context.SaveChangesAsync();
            return View("Filter",filter);
        }
    }
}

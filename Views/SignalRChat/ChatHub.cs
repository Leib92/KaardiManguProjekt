using KaardiManguProject.ApplicationServices.Services;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.ServiceInterface;
using KaardiManguProject.Data;
using KaardiManguProject.KaardiManguProject.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace KaardiManguProject.Views.SignalRChat
{

    public class ChatHub : Hub
    {
        private readonly KaardiManguProjectTARpe24Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ChatHub( KaardiManguProjectTARpe24Context context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task SendMessage(string user, string id, string message)
        {
            var messagelog = new ChatLog()
            {
                MessageID = Guid.NewGuid(),
                AccountID = id,
                MessageText = message,
                Date = DateTime.UtcNow

            };
            await _context.ChatLog.AddAsync(messagelog);
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
    }
}
using KaardiManguProject.ApplicationServices.Services;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.ServiceInterface;
using KaardiManguProject.Data;
using KaardiManguProject.KaardiManguProject.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            message = await FilterMessage(message);
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

        public async Task<string> FilterMessage(string message)
        {
            var filter = await _context.Filter.FirstOrDefaultAsync();

            if (filter == null)
                return message;

            var words = filter.FilterData
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var word in words)
            {
                string replacement = new string('*', word.Length);

                message = Regex.Replace(
                    message,
                    Regex.Escape(word),
                    replacement,
                    RegexOptions.IgnoreCase);
            }

            return message;
        }

    }
}
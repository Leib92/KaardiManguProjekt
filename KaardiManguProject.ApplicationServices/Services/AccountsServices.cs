using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Domain;
using KaardiManguProject.Core.Dto.AccountsDTOs;
using KaardiManguProject.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KaardiManguProject.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailsServices _emailsServices;

        public AccountsServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailsServices emailsServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailsServices = emailsServices;
        }
        public async Task<ApplicationUser> Register(ApplicationUserDTO userDTO)
        {
            var user = new ApplicationUser
            {
                UserName = userDTO.Email,
                Email = userDTO.Email,
                ProfileType = userDTO.ProfileType,
                AvatarName = userDTO.AvatarName,
            };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            return user;
        }
        public async Task<ApplicationUser> Login(LoginDTO userDTO)
        {
            var user = await _userManager.FindByEmailAsync(userDTO.Email);
            return user;
        }
    }
}

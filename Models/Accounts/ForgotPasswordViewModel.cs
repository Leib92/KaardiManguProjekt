using System.ComponentModel.DataAnnotations;

namespace KaardiManguProject.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

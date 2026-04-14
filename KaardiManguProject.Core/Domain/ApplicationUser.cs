using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KaardiManguProject.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public List<Guid>? FavoriteListIDs { get; set; }
        public List<Guid>? CommentIDs { get; set; }
        public string AvatarImageID { get; set; }
        public string AvatarName { get; set; }
        public bool ProfileType { get; set; }

        public string MainColor { get; set; } = "#ff0000";
        public string SecondaryColor { get; set; } = "#00ff00";
        public string TextColor { get; set; } = "#0000ff";
        public bool DarkMode { get; set; } = false; // Used to make the links white or black depending on the bool. 

        /* Ise mõeldud välja */
        public int? AvatarRating { get; set; } = 0;
        public string? Opinion {  get; set; }
    }
}

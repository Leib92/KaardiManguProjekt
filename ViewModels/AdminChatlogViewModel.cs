using KaardiManguProject.Core.Domain;
using KaardiManguProject.KaardiManguProject.Core.Domain;

namespace KaardiManguProject.ViewModels
{
    public class AdminChatlogViewModel
    {
        public List<ChatLog> ChatLogs { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}

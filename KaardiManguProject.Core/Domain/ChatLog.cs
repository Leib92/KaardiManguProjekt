using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KaardiManguProject.KaardiManguProject.Core.Domain
{
    
    public class ChatLog
    {
        [Key]
        public Guid MessageID { get; set; }
        public string AccountID { get; set; }
        public string? MessageText { get; set; }
        public DateTime? Date { get; set; }
    }
}

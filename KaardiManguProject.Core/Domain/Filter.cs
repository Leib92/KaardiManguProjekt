using System.ComponentModel.DataAnnotations;

namespace KaardiManguProject.KaardiManguProject.Core.Domain
{
    public class Filter
    {
        [Key]
        public Guid FilterID { get; set; }
        public List<string>? FilterData { get; set; }
    }
}

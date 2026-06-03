using System.ComponentModel.DataAnnotations;

namespace KaardiManguProject.KaardiManguProject.Core.Domain
{
    public class Filter
    {
        [Key]
        public Guid FilterID { get; set; } = Guid.Parse("ae7c0f13-1139-4859-a100-054f547b86ec");
        public string FilterData { get; set; } = "bomboclaat,sybau,fuck";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class Dependant
    {
        public int DepId { get; set; }

        [MaxLength(50)]
        public string? DeptName { get; set; }

        [MaxLength(50)]
        public string? Gender { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }


    }
}

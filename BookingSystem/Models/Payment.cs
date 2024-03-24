using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int? Amount { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? Date { get; set; }

        [MaxLength(50)]
        public string ? PaymentMethod { get; set; }

        public virtual Booking Booking { get; set; }
    }
}

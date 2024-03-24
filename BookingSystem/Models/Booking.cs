using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace BookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int? BookingId { get; set; }

        [Column(TypeName ="Date")]
        public DateTime? CheckInDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? CheckOutDate { get; set; }

        public int? Days {  get; set; }

        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }

        [ForeignKey("NonHotel")]
        public int? NonHotelId { get; set; }

        [ForeignKey("Payment")]
        public int? PayementId { get; set; }


        public virtual ApplicationUser? User { get; set; }

        public virtual Room? Room { get; set; }

        public virtual NonHotel? NonHotel { get; set; }

        public virtual Payment? Payment { get; set; }


    }
}

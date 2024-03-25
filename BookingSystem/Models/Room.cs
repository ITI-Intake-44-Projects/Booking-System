using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        [MaxLength(50)]
        public string? RoomType {  get; set; }

        [MaxLength(10)]
        public bool? Reserved { get; set; }

        public string? Description { get; set; }

        public int? PriceOfNight { get; set; }

        public string ? RoomNumber { get; set; }

        [ForeignKey("Hotel")]
        public int ? HotelId {  get; set; }

        public virtual Hotel? Hotel { get; set; }

        public virtual List<Booking>? Bookings { get; set; } = new List<Booking>();

        public virtual List<RoomImages>? RoomImages { get; set; } = new List<RoomImages>();

    }
}

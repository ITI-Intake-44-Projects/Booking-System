using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class NonHotel
    {
        public int NonHotelId {  get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [MaxLength(50)]
        public string ? Type { get; set; }

        public string ? Address { get; set; }

        [MaxLength(10)]
        public bool? Reserved { get; set; }

        [ForeignKey("Location")]
        public int LocationId {  get; set; }

        public virtual Location? Location { get; set; }

        public virtual List<Booking>? Bookings { get; set; } = new List<Booking>();

        public virtual List<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();

        public virtual List<NonHotelImages>? NonHotelImages { get; set; } = new List<NonHotelImages>();

    }
}

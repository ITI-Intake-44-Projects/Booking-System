using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [Range(0, 5)]
        public int? Rate { get; set; }

        [JsonIgnore]

        public virtual Location? Location { get; set; }

        [JsonIgnore]

        public virtual List<Booking>? Bookings { get; set; } = new List<Booking>();

        [JsonIgnore]

        public virtual List<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();

        [JsonIgnore]

        public virtual List<NonHotelImages>? NonHotelImages { get; set; } = new List<NonHotelImages>();

    }
}

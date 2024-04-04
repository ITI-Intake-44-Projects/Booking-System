using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookingSystem.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? HotelType { get; set; }

        public string? HotelDescription { get; set;}

        public string? Address { get; set; }

        [MaxLength(50)]
        public string? RoomNumber {  get; set; }

        [ForeignKey("Location")]
        public int? LocationId {  get; set; }

        [Range(0,5)]
        public int? Rate { get; set; }

        [JsonIgnore]
        public virtual Location? Location { get; set;}

        [JsonIgnore]

        public virtual List<Room>? Rooms { get; set; } = new List<Room>();

        [JsonIgnore]

        public virtual List<FeedBack>?FeedBacks { get; set; } = new List<FeedBack>();

        [JsonIgnore]

        public virtual List<HotelImages>?HotelImages { get; set; } = new List<HotelImages>();

    }
}

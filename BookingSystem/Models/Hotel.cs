using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        
        public virtual Location? Location { get; set;}

        public virtual List<Room>? Rooms { get; set; } = new List<Room>();

        public virtual List<FeedBack>?FeedBacks { get; set; } = new List<FeedBack>();

        public virtual List<HotelImages>?HotelImages { get; set; } = new List<HotelImages>();

    }
}

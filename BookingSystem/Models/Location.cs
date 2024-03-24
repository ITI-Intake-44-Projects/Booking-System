using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class Location
    {
        [Key]
        public int LocationId {  get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        public virtual List<Hotel>? Hotels { get; set; } = new List<Hotel>();

        public virtual List<NonHotel>? NonHotels { get; set; } = new List<NonHotel>();



    }
}

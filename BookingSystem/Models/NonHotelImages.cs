using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class NonHotelImages
    {
        public byte[] Image { get; set; }

        [ForeignKey("NonHotel")]
        public int NonHotelId { get; set; }

        public virtual NonHotel? NonHotel { get; set; }
    }
}

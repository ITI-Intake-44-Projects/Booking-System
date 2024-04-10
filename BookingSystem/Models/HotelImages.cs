using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class HotelImages
    {
        public byte[]? Image { get; set; }

        [ForeignKey("Hotel")]
        public int? HotelId { get; set; }

        public virtual Hotel? Hotel {  get; set; }
    }
}

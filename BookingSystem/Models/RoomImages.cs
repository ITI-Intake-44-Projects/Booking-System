using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class RoomImages
    {
        public byte[]? Image { get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }

        public virtual Room? Room { get; set; }
    }
}

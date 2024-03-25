using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedbackId { get; set; }

        public String? Feedback { get; set; }

        public int? Rate { get; set; }

        [ForeignKey("User")]
        public string User_Id { get; set; }

        [ForeignKey("Hotel")]
        public int? Hotel_Id { get; set; }

        [ForeignKey("NonHotel")]
        public int? NonHotel_Id { get; set; }

        public virtual ApplicationUser? User { get; set; }

        public virtual Hotel? Hotel { get; set; }

        public virtual NonHotel? NonHotel { get; set; }
      
    }
}

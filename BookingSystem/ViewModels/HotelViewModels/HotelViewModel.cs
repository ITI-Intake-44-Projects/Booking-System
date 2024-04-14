using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class HotelViewModel
    {
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public string HotelDescription { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
        
        //[Required(ErrorMessage = "Image is required.")]
        //public byte[] Image { get; set; }
    }
}

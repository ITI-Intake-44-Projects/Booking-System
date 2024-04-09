using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class InsertHotelViewModel
    {
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(50)]
        public string HotelType { get; set; }

        public string HotelDescription { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}

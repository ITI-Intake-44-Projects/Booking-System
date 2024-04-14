using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class InsertNonHotelViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Reserved is required.")]
        public bool? Reserved { get; set; }
        public string Description { get; set; }

        // for location
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}

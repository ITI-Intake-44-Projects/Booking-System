using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class InsertHotelViewModel
    {
        //public int HotelId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public string HotelDescription { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        //[Required(ErrorMessage = "Please choose an image.")]
        //public IFormFile ImageFile { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels.HotelViewModels
{
    public class EditHotelViewModel
    {
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(50)]
        public string HotelType { get; set; }

        public string HotelDescription { get; set; }

        //public string Address { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }
    }

}

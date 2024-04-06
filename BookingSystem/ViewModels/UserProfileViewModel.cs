using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    public class UserProfileViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public IFormFile? ImageForm { get; set; }

        public byte[]? Image { get; set; } 

        public string? ImageBase64 => Image != null ? Convert.ToBase64String(Image) : null;



    }
}

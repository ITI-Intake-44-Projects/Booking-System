using BookingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.ViewModels
{
    
    public class RegisterUserVM
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public List<string>? Countires { get; set; }

        public List<string>? Cities { get; set; }



    }
}

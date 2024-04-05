using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {

       public string? FirstName {  get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        public byte[]? Image { get; set; }

        public virtual List<Dependant>? Dependants { get; set; } = new List<Dependant>();

        public virtual List<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();

        public virtual List<Booking>? Bookings { get; set; } = new List<Booking>();



    }
}

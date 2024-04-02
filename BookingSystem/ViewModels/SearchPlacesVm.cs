using BookingSystem.Models;

namespace BookingSystem.ViewModels
{
    public class SearchPlacesVm
    {
        public string Name { get; set; }

        public string HotelType { get; set; }
        public string HotelDescription { get; set; }

        public string Address { get; set; }

        public virtual string? HotelImage { get; set; }

        public virtual Location ? Location { get; set; }

    }
}

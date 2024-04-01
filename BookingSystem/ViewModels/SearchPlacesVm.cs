using BookingSystem.Models;

namespace BookingSystem.ViewModels
{
    public class SearchPlacesVm
    {
        public string Name { get; set; }

        public string HotelType { get; set; }
        public string HotelDescription { get; set; }

        public string Address { get; set; }

        public virtual List<string>? HotelImages { get; set; } = new List<string>();


    }
}

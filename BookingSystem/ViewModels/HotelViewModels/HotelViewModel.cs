namespace BookingSystem.ViewModels
{
    public class HotelViewModel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string HotelType { get; set; }
        public string HotelDescription { get; set; }
        public string Address { get; set; }
        public LocationViewModel Location { get; set; }
    }
}

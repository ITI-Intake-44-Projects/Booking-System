namespace BookingSystem.ViewModels
{
    public class RoomViewModel
    {

        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public decimal PriceOfNight { get; set; }
        public string HotelName { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
    }
}

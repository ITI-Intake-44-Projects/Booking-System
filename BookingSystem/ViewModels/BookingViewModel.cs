namespace BookingSystem.ViewModels
{
    public class BookingViewModel
    {  // Include properties from Booking entity that are needed in the view
        public string GuestName { get; set; }
        public string Email { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public string SpecialRequests { get; set; }
        public int cardNumber { get; set; }
        public string Country { get; set; }
        public string CardholderName { get; set; }
    }
}

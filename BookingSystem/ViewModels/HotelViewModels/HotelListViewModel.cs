namespace BookingSystem.ViewModels
{
    // Pagination
    public class HotelListViewModel
    {
        public List<HotelViewModel> Hotels { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}

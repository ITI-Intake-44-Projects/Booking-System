namespace BookingSystem.ViewModels
{
    // Pagination
    public class NonHotelListViewModel
    {
        public List<NonHotelViewModel> NonHotels { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}

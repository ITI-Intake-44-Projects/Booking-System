namespace BookingSystem.ViewModels
{
    public class MostVisitedPlacesViewModel
    {
        //public List<string>? CityName { get; set; } = new List<string>();
        public string CityName { get; set; }
        
        public string CountryName { get; set; }

        public int Visits { get; set; }

        public string CityImage { get; set; }
    }
}
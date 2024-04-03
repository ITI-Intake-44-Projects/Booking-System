using BookingSystem.Models;

namespace BookingSystem.ViewModels
{
    public class SearchPlacesVm
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }

        public int Rate { get; set; }

        public bool? Reserved { get; set; }

        public virtual string? Image { get; set; }



        public virtual Location ? Location { get; set; }

    }
}

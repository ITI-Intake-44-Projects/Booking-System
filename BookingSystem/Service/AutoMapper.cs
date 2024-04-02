using AutoMapper;
using BookingSystem.Models;
using BookingSystem.ViewModels;

namespace BookingSystem.Service
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<RegisterUserVM, ApplicationUser>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.Image)));
            CreateMap<Hotel, SearchPlacesVm>()
            .ForMember(dest => dest.HotelImage, opt => opt.MapFrom(src =>
            src.HotelImages.Select(HotelImages => Convert.ToBase64String(HotelImages.Image)).FirstOrDefault()));
        }

        private static byte[] ConvertFormFileToByteArray(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

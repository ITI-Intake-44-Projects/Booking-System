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
           .ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
           src.HotelImages.Select(HotelImages => Convert.ToBase64String(HotelImages.Image)).FirstOrDefault()))
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.HotelType))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.HotelDescription))
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.HotelId));

            CreateMap<NonHotel, SearchPlacesVm>()
              .ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
               src.NonHotelImages.Select(NonHotelImages => Convert.ToBase64String(NonHotelImages.Image)).FirstOrDefault()))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NonHotelId));

            CreateMap<Room, RoomViewModel>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.RoomImages.Select(r => Convert.ToBase64String(r.Image)).FirstOrDefault()));

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

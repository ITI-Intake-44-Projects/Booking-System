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

using AutoMapper;
using BookingSystem.Models;
using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BookingSystem.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
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

            CreateMap<UserProfileViewModel, ApplicationUser>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.ImageForm)));

            
            CreateMap<ApplicationUser, UserProfileViewModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.ImageForm, opt => opt.MapFrom(src => ConvertByteArrayToFormFile(src.Image)));
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

        private static IFormFile ConvertByteArrayToFormFile(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }

            // Create a memory stream from byte array
            using (var memoryStream = new MemoryStream(bytes))
            {
                // Create a new form file
                return new FormFile(memoryStream, 0, bytes.Length, null, null);
            }
        }
    }
}

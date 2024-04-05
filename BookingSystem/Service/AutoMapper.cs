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
            CreateMap<UserProfileViewModel, ApplicationUser>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertFormFileToByteArray(src.ImageForm)));
            //CreateMap<ApplicationUser, UserProfileViewModel>()
            //    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertByteArrayToFormFile(src.Image)));
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

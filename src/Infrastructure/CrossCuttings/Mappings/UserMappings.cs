

using AutoMapper;
using Domain.Models;

namespace Infrastructure.CrossCuttings.Mappings
{
    public class UserMappings:Profile
    {
        
        public UserMappings()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
